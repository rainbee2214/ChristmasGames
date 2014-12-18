﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SnowflakeMachine : MonoBehaviour 
{
    public int poolSize = 10;
    List<GameObject> snowflakes;
    float gravityScaleUpper = 0.01f, gravityScaleLower = 0.002f;
    Vector2 startingPosition;

    float xBound = 3f;//Camera.main.orthographicSize;
    public bool addSnowflake = true;

    float nextReleaseTime = 5f;
    float delay = 1f;

	void Start () 
    {
        GetSnowflakes();
	}
	

    void Update()
    {
        if (addSnowflake && Time.time > nextReleaseTime)
        {
            nextReleaseTime += delay;
            //addSnowflake = false;
           AddSnowFlake();
        }

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Mouse left click");

        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint((Input.GetTouch(0).position)), Vector2.zero);
            if (hit.collider != null)
            {
                Camera.main.backgroundColor = Color.white;
            }
            else
            {
                Camera.main.backgroundColor = Color.black;

            }
        }
    }


    void GetSnowflake()
    {
    }

    void AddSnowFlake()
    {
        if (snowflakes == null) snowflakes = new List<GameObject>();
        startingPosition.x = Random.Range(-xBound, xBound);
        startingPosition.y = transform.position.y;

        snowflakes.Add(Instantiate(Resources.Load(("Snowflakes/Snowflake" + Random.Range(1,7)), typeof(GameObject)), startingPosition, Quaternion.identity) as GameObject);
        int i = snowflakes.Count;
        snowflakes[i-1].name = i + "Snowflake";
        snowflakes[i-1].gameObject.AddComponent<Rigidbody2D>();

        snowflakes[i-1].gameObject.GetComponent<Rigidbody2D>().gravityScale = Random.Range(gravityScaleLower, gravityScaleUpper);
    }

    void GetSnowflakes()
    {
        snowflakes = new List<GameObject>();
        for (int i = 1; i <= poolSize; i++)
        {
            AddSnowFlake();
        }
    }
}
