using UnityEngine;
using System.Collections;

public class TouchController : MonoBehaviour 
{
    public Color[] colors;
    int currentColor;

    public bool canvasOff = false;
    GameObject thisCanvas;

    void Start()
    {
        thisCanvas = gameObject.GetComponentInChildren<Canvas>().gameObject;
        if (Application.loadedLevelName != "Menu")
        {
            thisCanvas.SetActive(false);
            canvasOff = true;
        }
    }
	void Update () 
    {
        if (Input.touchCount > 0)
        {
            //Do what with input?
            //Check for other conditions, are they allowed to touch ? how many fingers? are they touching the right place on screen ?

            //if (Input.touchCount == 2 )
            //{
            //    Camera.main.backgroundColor = Color.white;
            //}
            //else 
            //{
            //    if (Input.GetTouch(0).phase == TouchPhase.Moved)
            //    {
            //        Camera.main.backgroundColor = Color.black;
            //    }

            //    if (Input.GetTouch(0).phase == TouchPhase.Stationary)
            //    {
            //        Camera.main.backgroundColor = Color.green;
            //    }
            //    if (Input.GetTouch(0).phase == TouchPhase.Ended)
            //    {
            //        Camera.main.backgroundColor = Color.yellow;
            //    }
            //}
        }
        else
        {
            Camera.main.backgroundColor = colors[currentColor];
        }
	}

    public void ChangeBackGroundColor()
    {
        Camera.main.backgroundColor = colors[currentColor];
        currentColor++;
        if (currentColor >= colors.Length) currentColor = 0;
    }

    public void SwitchCanvas()
    {
        if (canvasOff)
        {
            thisCanvas.SetActive(true);
            canvasOff = false;
        }
        else
        {
            thisCanvas.SetActive(false);
            canvasOff = true;
        }
    }
 
    public void Quit()
    {
        Application.Quit();
    }

    public void LoadLevel(string level)
    {
        Application.LoadLevel(level);
    }
}
