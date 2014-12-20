using UnityEngine;
using System.Collections;

public class TreeChopperController : MonoBehaviour 
{
    public static TreeChopperController controller;
    public static int rows = 2;
    public static int columns = 3;

    public float score = 1f;
    public int level = 1;

	void Start () 
    {
        controller = this;
	}
	
	void Update () 
    {
	
	}
}
