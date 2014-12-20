using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour 
{
    void OnPointerDown()
    {
        Debug.Log("On pointer down");
    }

    void OnPointerUp()
    {
        Debug.Log("On pointer up");
    }
}
