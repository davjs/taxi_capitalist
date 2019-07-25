using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextMeshManager : MonoBehaviour
{
    public GameObject textObj;
    private static GameObject internalTextObj;

    public void Start()
    {
        internalTextObj = textObj; 
    }

    public static void InstantiateText(Vector3 position, string text, string id)
    {
        var obj = Instantiate<GameObject>(internalTextObj, position, Quaternion.Euler(90,0,0));
        var tmp = obj.GetComponent<TextMeshPro>();
        tmp.text = text;

        switch (id)
        {
            case "1":
                tmp.color = Color.red;
                break;
            case "2":
                tmp.color = Color.cyan;
                break;
            case "3":
                tmp.color = Color.magenta;
                break;
            case "4":
                tmp.color = Color.blue;
                break;
            default:
                tmp.color = Color.white;
                break;
        }
    }
}