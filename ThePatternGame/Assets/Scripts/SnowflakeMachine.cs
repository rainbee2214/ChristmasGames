using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SnowflakeMachine : MonoBehaviour 
{
    public bool addSnowflake = true;
    public int poolSize = SnowflakesController.poolSize;
    int maxSize = SnowflakesController.maxSize;

    float gravityScaleUpper = 0.04f;
    float gravityScaleLower = 0.005f;
    float xBound = 3f;
    List<GameObject> snowflakes;
    Vector2 startingPosition;
    float nextReleaseTime = 3f;
    float delay = 0.75f;
    int lastSnowflake = 0;

	void Start () 
    {
        GetSnowflakes();
	}
	

    void Update()
    {
        if (addSnowflake && Time.time > nextReleaseTime)
        {
            nextReleaseTime += delay;
            AddSnowFlake();
        }

        if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint((Input.GetTouch(0).position)), Vector2.zero);
            if (hit.collider != null)
            {
                hit.collider.gameObject.SetActive(false);
                SnowflakesController.controller.UpdateScore(1f);
            }
        }
    }


    void GetSnowflake()
    {
    }

    void AddSnowFlake()
    {
        if (snowflakes.Count >= maxSize)
        {
            snowflakes[lastSnowflake].gameObject.SetActive(false);
            startingPosition.x = Random.Range(-xBound, xBound);
            startingPosition.y = transform.position.y;
            snowflakes[lastSnowflake].transform.position = startingPosition;

            snowflakes[lastSnowflake].gameObject.SetActive(true);
            lastSnowflake++;
            if (lastSnowflake >= snowflakes.Count) lastSnowflake = 0;
        }
        else
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
