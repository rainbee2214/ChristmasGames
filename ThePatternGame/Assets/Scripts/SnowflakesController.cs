using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SnowflakesController : MonoBehaviour 
{
    public static int maxScore = 100;
    public static int minScore = 0;

    public static SnowflakesController controller;

    public float score = 0f;
    public bool updateScore = false;

    public Slider slider;

    void Start()
    {
        controller = this;
    }

    void Update()
    {
        if (updateScore) SnowflakesController.controller.UpdateScore(1f);
    }

    public void UpdateScore(float value)
    {
        updateScore = false;
        score += value;
        slider.value = score;
        if (score > maxScore) score = maxScore;
        else if(score < minScore) score = minScore;
    }
}
