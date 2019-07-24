using System;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

namespace Taxi
{
    public class PlayerRigidbodyMovementController : MonoBehaviour
    {
        public float velocity = 15;
        public float rotationSpeed = 180;
        public ParticleSystem speedyParticles;
        public PlayerMovementType movementType;

        private PlayerInputController inputController;
        private new Rigidbody rigidbody;

        private void Start()
        {
            inputController = GetComponent<PlayerInputController>();
            rigidbody = GetComponent<Rigidbody>();
        }

        void Update()
        {
            rigidbody.useGravity = transform.position.y > 0.6f;
            if (rigidbody.velocity.magnitude > 50)
            {
                speedyParticles.Emit(200);
            }

            switch (movementType)
            {
                case PlayerMovementType.ManualRotation:
                    UpdateMoveManualRotation();
                    return;

                case PlayerMovementType.AdaptiveRotation:
                    UpdateMoveAdaptiveRotation();
                    return;
                case PlayerMovementType.Slide:
                    UpdateMoveSlide();
                    return;
                default:
                    UpdateMoveAdaptiveRotation();
                    return;
            }
        }

        private void UpdateMoveSlide()
        {
            this.rigidbody.AddForce(inputController.horizontal * Vector3.right * velocity * Time.deltaTime);
            this.rigidbody.AddForce(inputController.vertical * Vector3.forward * velocity * Time.deltaTime);

            if (this.rigidbody.velocity.magnitude >= 30)
            {
                rigidbody.velocity = new Vector3(Math.Min(rigidbody.velocity.x, 30), rigidbody.velocity.y,
                    Math.Min(rigidbody.velocity.z, 30));
            }
        }

        private void UpdateMoveManualRotation()
        {
            this.rigidbody.AddForce(inputController.vertical * this.transform.forward * velocity * Time.deltaTime);
            var rotationAmount = rotationSpeed * Time.deltaTime * inputController.horizontal;
            this.rigidbody.AddTorque(0, rotationAmount, 0);
        }

        private void UpdateMoveAdaptiveRotation()
        {
            var inputDirection = new Vector3(inputController.horizontal, 0, inputController.vertical);
            var thrust = Vector3.Dot(inputDirection.normalized, this.transform.forward);
            var rotation =
                Vector3.Dot(inputDirection.normalized, this.transform.right); //Is the controller aimed left or right?

            this.rigidbody.AddForce(
                thrust * inputDirection.magnitude * this.transform.forward * velocity *
                Time.deltaTime /* * inputDirection.magnitude*/);
            var rotationAmount = rotationSpeed * Time.deltaTime * rotation;
            this.rigidbody.AddTorque(0, rotationAmount, 0);
        }
    }
}