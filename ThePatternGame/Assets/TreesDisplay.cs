using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TreesDisplay : MonoBehaviour
{
    void Update()
    {
        gameObject.GetComponent<Text>().text = "Trees: " + TreeChopperController.controller.trees;
    }
}
