using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SnowflakesController : MonoBehaviour 
{
    public static int maxHealth = 50;
    public static int minHealth = 0;
    public static int poolSize = 3;
    public static int maxSize = 60;
    public static int maxLevel = 11;
    public static int startingHealth = 25;

    public static float gravityScaleUpper = 0.04f;
    public static float gravityScaleLower = 0.005f;
    public static float xBound = 6f;
    public static float delay = 0.75f;
    public static float burstDelay = 5;
    public static int burstSize = 5;

    public static SnowflakesController controller;

    public float score;
    public float health = 0f;
    public int level = 1;
    public bool updateHealth = false;

    public Slider slider;
    public Text text;

    void Start()
    {
        health += SnowflakesController.startingHealth;
        slider.value = health;
        controller = this;
    }

    void Update()
    {
        if (updateHealth) SnowflakesController.controller.UpdateHealth(1f);
        if (health == maxHealth) LevelUp();
        if (health == minHealth) Application.LoadLevel("GameOver");
    }

    public void UpdateScore(float value)
    {
        score += value;
        UpdateHealth(value);
    }

    public void UpdateHealth(float value)
    {
        updateHealth = false;
        health += value;
        slider.value = health;
        if (health > maxHealth) health = maxHealth;
        else if (health < minHealth) health = minHealth;
    }

    public void LevelUp()
    {
        ShowLevelUpMessage();

        level++;
        health = SnowflakesController.startingHealth;
        SnowflakesController.maxHealth += 10;
        SnowflakesController.burstDelay -= 0.25f;
        SnowflakesController.burstSize++;
        SnowflakesController.gravityScaleLower += 0.002f;
        SnowflakesController.delay -= 0.025f;

        if (level >= maxLevel) Application.LoadLevel("Win");
    }

    public void ShowLevelUpMessage()
    {
        text.gameObject.SetActive(true);
    }
}
