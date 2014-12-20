using UnityEngine;
using System.Collections;

public class LevelLoader : MonoBehaviour 
{
    public float delay = 5f;
    public string levelToLoad;

    public void Update()
    {
        if (Time.timeSinceLevelLoad > delay)
            LoadLevel(levelToLoad);
        
    }

    public void LoadLevel(string level)
    {
        Application.LoadLevel(level);
    }
}
