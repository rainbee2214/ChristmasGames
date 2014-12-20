using UnityEngine;
using System.Collections;

public class SleighRideController : MonoBehaviour 
{
    public static int poolSize = 20;
    public static float dropDelay = 1f;
    public static float gravityLowerBound = 0.01f;
    public static float gravityUpperBound = 0.1f;
    public static float xBound = 5f;

    public static SleighRideController controller;

    public GameObject toyCatchSound;
    public GameObject hitGroundSound;

    public int score;
    public int level;

	void Start () 
    {
        hitGroundSound = Instantiate(Resources.Load("Audio/HitGroundSound", typeof(GameObject))) as GameObject;
        toyCatchSound = Instantiate(Resources.Load("Audio/ToyCatchSound", typeof(GameObject))) as GameObject;
    
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
