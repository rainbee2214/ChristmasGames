using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SnowmanHits : MonoBehaviour 
{
     
     void Update()
    {
        gameObject.GetComponent<Text>().text = "Snowman Hits Left: " + SleighRideController.controller.snowmanHits;
    }
}
