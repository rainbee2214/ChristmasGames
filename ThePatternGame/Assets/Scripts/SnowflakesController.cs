using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SnowflakesController : MonoBehaviour 
{
    public static int maxHealth = 50;
    public static int minHealth = 0;
    public static int poolSize = 4;
    public static int maxSize = 60;
    public static int maxLevel = 11;
    public static int startingHealth = 25;

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

        if (level >= maxLevel) Application.LoadLevel("Win");
    }

    public void ShowLevelUpMessage()
    {
        text.gameObject.SetActive(true);
    }
}
