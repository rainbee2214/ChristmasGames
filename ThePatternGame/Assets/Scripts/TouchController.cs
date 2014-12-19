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
