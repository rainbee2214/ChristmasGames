using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Score : MonoBehaviour 
{
	void Update () 
    {
        if (Application.loadedLevelName == "Snowflakes") gameObject.GetComponent<Text>().text = "Score: " + SnowflakesController.controller.score;
        else if (Application.loadedLevelName == "TreeChopper") gameObject.GetComponent<Text>().text = "Score: " + TreeChopperController.controller.score;	
    }
}
