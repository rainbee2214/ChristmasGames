using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadeOut : MonoBehaviour 
{
    public float speed = 0.01f;
    public float delay = 3f;

	void Update () 
    {
	    if (Time.timeSinceLevelLoad > delay)
        {
            Text text = GetComponent<Text>();
            Color color = text.color;
            Color finalColor = color;
            finalColor.a = 0;

            text.color = Color.Lerp(color, finalColor, Time.time*speed);
        }
	}


}
