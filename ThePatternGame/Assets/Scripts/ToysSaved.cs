using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ToysSaved : MonoBehaviour 
{
    void Update()
    {
        if (gameObject.name == "ToysSaved") gameObject.GetComponent<Text>().text = "Toys Saved:  " + SleighRideController.controller.toysSaved;
        else if (gameObject.name == "ToysDestroyed") gameObject.GetComponent<Text>().text = "Toys Destroyed:  " + SleighRideController.controller.toysDestroyed;
        
    }
}
