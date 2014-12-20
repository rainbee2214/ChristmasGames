using UnityEngine;
using System.Collections;

public class SleighRideController : MonoBehaviour 
{
    public static int poolSize = 20;
    public static float dropDelay = 1f;
    public static float gravityLowerBound = 0.01f;
    public static float gravityUpperBound = 0.1f;
    public static float scaleLowerBound = 0.2f;
    public static float scaleUpperBound = 0.4f;
    public static float xBound = 5f;
    public static int toyCountForNextLevel = 4;
    public static int maxToysDestroyed = 20;
    public static int maxLevel = 10;

    public static SleighRideController controller;

    public GameObject toyCatchSound;
    public GameObject hitGroundSound;
    public GameObject snowmanCrush;

    public int toysSaved;
    public int toysDestroyed;
    public int score;
    public int level;
    public int snowmanHits = 3;

	void Start () 
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;

        hitGroundSound = Instantiate(Resources.Load("Audio/HitGroundSound", typeof(GameObject))) as GameObject;
        toyCatchSound = Instantiate(Resources.Load("Audio/ToyCatchSound", typeof(GameObject))) as GameObject;
        snowmanCrush = Instantiate(Resources.Load("Audio/SnowmanCrush", typeof(GameObject))) as GameObject;
        controller = this;
	}
	
	void Update () 
    {
        if (snowmanHits == 0) Application.LoadLevel("GameOver");
        if (score < 0) score = 0;
        if (toysSaved >= SleighRideController.toyCountForNextLevel) LevelUp();
        if (level > maxLevel) Application.LoadLevel("Win");
	}

    void LevelUp()
    {
        level++;
        SleighRideController.dropDelay -= 0.1f;
        SleighRideController.gravityLowerBound += 0.01f;
        SleighRideController.gravityUpperBound += 0.01f;
        SleighRideController.toyCountForNextLevel += level*2;
        SleighRideController.maxToysDestroyed--;
    }
}
