using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Level : MonoBehaviour
{
    void Update()
    {
        gameObject.GetComponent<Text>().text = "Level " + SnowflakesController.controller.level;
    }
}
