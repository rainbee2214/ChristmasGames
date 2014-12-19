using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SnowflakesController : MonoBehaviour 
{
    public static int maxScore = 100;
    public static int minScore = 0;
    public static int poolSize = 4;
    public static int maxSize = 60;
    public static int startingScore = 25;

    public static SnowflakesController controller;

    public float score = 0f;
    public bool updateScore = false;

    public Slider slider;

    void Start()
    {
        score += SnowflakesController.startingScore;
        slider.value = score;
        controller = this;
    }

    void Update()
    {
        if (updateScore) SnowflakesController.controller.UpdateScore(1f);
        if (score == maxScore) Application.LoadLevel("Win");
        if (score == minScore) Application.LoadLevel("GameOver");
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
