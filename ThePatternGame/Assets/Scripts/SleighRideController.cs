using UnityEngine;
using System.Collections;

public class SleighRideController : MonoBehaviour 
{
    public static float poolSize = 20;
    public static float dropDelay = 1f;
    public static float gravityLowerBound = 0.01f;
    public static float gravityUpperBound = 0.1f;

    public static SleighRideController controller;

    public int score;
    public int level;

	void Start () 
    {
        controller = this;
	}
	
	void Update () 
    {
	
	}

    void LevelUp()
    {
        dropDelay -= 0.1f;
        gravityLowerBound += 0.01f;
        gravityUpperBound += 0.01f;
    }
}
