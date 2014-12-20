using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadeOut : MonoBehaviour 
{
    public float speed = 0.01f;
    public float delay = 3f;
    public bool loop = false;

    Color startingColor;
    Text text;

    void Start()
    {
        text = GetComponent<Text>();
        startingColor = text.color;
    }

	void Update () 
    {
        if (loop)
        {
            Color color = text.color;
            Color finalColor = color;
            finalColor.a = 0;

            text.color = Color.Lerp(color, finalColor, Time.time * speed);
            if (text.color == finalColor)
            {
                text.color = startingColor;
                gameObject.SetActive(false);
            }
        }
        else
        {
	        if (Time.timeSinceLevelLoad > delay)
            {
                Color color = text.color;
                Color finalColor = color;
                finalColor.a = 0;

                text.color = Color.Lerp(color, finalColor, Time.time*speed);
                if (text.color == finalColor)
                {
                    text.color = startingColor;
                    gameObject.SetActive(false);
                }
            }
        }
	}

}
