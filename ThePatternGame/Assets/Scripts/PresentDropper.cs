using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PresentDropper : MonoBehaviour 
{
    public Color[] colors;
    int poolSize = SleighRideController.poolSize;
    List<GameObject> toys = new List<GameObject>();
    int topToy = 0;
    float nextDropTime;
    float dropDelay = SleighRideController.dropDelay;

    List<Sprite> toySprites = new List<Sprite>();

    bool snowmanDropper = false;

	void Start () 
    {
        if (gameObject.name == "SnowmanDropper") snowmanDropper = true;
        if (colors == null)
        {
            colors = new Color[1];
            colors[0] = Color.red;
        }
        GetToySprites();
        BuildToys();
	}
	
	void Update () 
    {
        if (snowmanDropper)
        {
            if (poolSize < SleighRideController.poolSize)
            {
                poolSize = SleighRideController.poolSize;
                AddToys(5);
            }
        }
        else
        {
	        if (poolSize < SleighRideController.poolSize)
            {
                poolSize = SleighRideController.poolSize;
                AddToys();
            }

        }
            if (Time.time > nextDropTime) DropToy();
	}

    public void DropToy()
    {
        toys[topToy].gameObject.rigidbody2D.gravityScale = Random.Range(SleighRideController.gravityLowerBound, SleighRideController.gravityUpperBound);

        if (snowmanDropper)
        {
            nextDropTime = Time.time + dropDelay * 10;
            toys[topToy].gameObject.GetComponent<SpriteRenderer>().sprite = toySprites[5];
            toys[topToy].gameObject.GetComponent<SpriteRenderer>().color = colors[0];
            float randomScale = Random.Range(SleighRideController.scaleLowerBound*2, SleighRideController.scaleUpperBound);
            toys[topToy].transform.localScale = new Vector3(randomScale, randomScale, 1f);
        }
        else
        {
            nextDropTime = Time.time + dropDelay;
            toys[topToy].gameObject.GetComponent<SpriteRenderer>().sprite = toySprites[Random.Range(0, 5)];
            toys[topToy].gameObject.GetComponent<SpriteRenderer>().color = colors[Random.Range(0, colors.Length - 1)];
            float randomScale = Random.Range(SleighRideController.scaleLowerBound, SleighRideController.scaleUpperBound);
            toys[topToy].transform.localScale = new Vector3(randomScale, randomScale, 1f);
        }
        
        toys[topToy].transform.rotation = Quaternion.Euler(0, 0, Random.Range(-45, 45));
        Vector2 position = transform.position;
        position.x = Random.Range(-SleighRideController.xBound, SleighRideController.xBound);
        toys[topToy].transform.position = position;
        toys[topToy].SetActive(true);
        topToy++;
        if (topToy >= toys.Count) topToy = 0;
    }

    void AddToys()
    {
        for (int i = toys.Count; i < poolSize; i++)
        {
            toys.Add(Instantiate(Resources.Load("SleighRide/toy", typeof(GameObject))) as GameObject);
            toys[i].transform.parent = transform;
            toys[i].name = "Toy" + i;
        }
    }

    void AddToys(int toyIndex)
    {
        for (int i = toys.Count; i < poolSize; i++)
        {
            toys.Add(Instantiate(Resources.Load("SleighRide/toy", typeof(GameObject))) as GameObject);
            toys[i].transform.parent = transform;
            toys[i].name = "Snowman" + i;
            toys[topToy].gameObject.GetComponent<SpriteRenderer>().sprite = toySprites[toyIndex];
            toys[topToy].gameObject.GetComponent<SpriteRenderer>().color = colors[0];
      
        }
    }

    void BuildToys()
    {
        for (int i = 0; i < poolSize; i++)
        {
            toys.Add(Instantiate(Resources.Load("SleighRide/toy", typeof(GameObject))) as GameObject);
            Vector2 position = transform.position;
            position.x = Random.Range(-SleighRideController.xBound, SleighRideController.xBound);
            toys[i].transform.parent = transform;
            if (gameObject.name == "SnowmanDropper")
            {
                toys[i].name = "Snowman" + i;
                toys[i].tag = "Snowman";
                toys[topToy].gameObject.GetComponent<SpriteRenderer>().sprite = toySprites[5];
                toys[topToy].gameObject.GetComponent<SpriteRenderer>().color = colors[0];
            }
            else
            {
                toys[i].name = "Toy" + i;
                toys[i].tag = "Toy";

            }
            toys[i].transform.position = position;
        }
    }

    void GetToySprites()
    {
        for (int i = 1; i <= 6; i++)
        {
            toySprites.Add(Instantiate(Resources.Load("Sprites/Sleigh/toy" + i, typeof(Sprite))) as Sprite);
        }
    }
}
