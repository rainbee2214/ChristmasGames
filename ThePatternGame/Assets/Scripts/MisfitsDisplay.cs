using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MisfitsDisplay : MonoBehaviour
{
    void Update()
    {
        gameObject.GetComponent<Text>().text = "Misfits: " + TreeChopperController.controller.misfits;
    }
}
