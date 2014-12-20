using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Score : MonoBehaviour 
{
	void Update () 
    {
        gameObject.GetComponent<Text>().text = "Score: "+ SnowflakesController.controller.score;
	}
}
