using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Level : MonoBehaviour
{
    void Update()
    {
        if (Application.loadedLevelName == "Snowflakes") gameObject.GetComponent<Text>().text = "Level " + SnowflakesController.controller.level;
        if (Application.loadedLevelName == "TreeChopper") gameObject.GetComponent<Text>().text = "Level " + TreeChopperController.controller.level;
    
    }
}
