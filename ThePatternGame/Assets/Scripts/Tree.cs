using UnityEngine;
using System.Collections;

public class Tree : MonoBehaviour 
{
    public TreeChopperController.Status status;

    float timeStartedGrowing;
    float growthTime = TreeChopperController.growthTime;
    float fullGrownPeriod = TreeChopperController.fullGrownPeriod;
    float deathTime = TreeChopperController.deathTime;

    float increment;
    float nextGrowthTime;
    public float speed = 0.00005f;

    Vector2 startingScale = new Vector2(0.25f, 0.25f);
    
    void Start()
    {
        ActivateTree();
    }

	void Update () 
    {

        if (status == TreeChopperController.Status.Dead && gameObject.activeSelf)
        {
            ActivateTree();
        }

        if (Time.time > timeStartedGrowing + growthTime) status = TreeChopperController.Status.FullGrown;
        if (Time.time > timeStartedGrowing + growthTime + fullGrownPeriod) status = TreeChopperController.Status.Dying;  
        if (Time.time > timeStartedGrowing + growthTime + fullGrownPeriod + deathTime) status = TreeChopperController.Status.Dead;

        switch(status)
        {
            case TreeChopperController.Status.Growing: gameObject.GetComponent<SpriteRenderer>().color = TreeChopperController.controller.growingColor; break;
            case TreeChopperController.Status.FullGrown: gameObject.GetComponent<SpriteRenderer>().color = TreeChopperController.controller.fullGrownColor; break;
            case TreeChopperController.Status.Dying: gameObject.GetComponent<SpriteRenderer>().color = TreeChopperController.controller.dyingColor; break;
            case TreeChopperController.Status.Dead: gameObject.GetComponent<SpriteRenderer>().color = TreeChopperController.controller.deadColor; break;
        }

        if (status == TreeChopperController.Status.Growing)
        {
            Vector2 scale = transform.localScale;
            Vector2 fullScale = new Vector2(1.2f, 1.2f);
            transform.localScale = Vector2.Lerp(scale, fullScale, (Time.time - timeStartedGrowing)*speed);
        }
        else if (status == TreeChopperController.Status.FullGrown)
        {
        }
        else if (status == TreeChopperController.Status.Dying)
        {
            Color endColor = TreeChopperController.controller.dyingColor;

            gameObject.GetComponent<SpriteRenderer>().color = Color.Lerp(gameObject.GetComponent<SpriteRenderer>().color, endColor, Time.time * speed);
        }
        else if (status == TreeChopperController.Status.Dead)
        {
            ActivateTree();
        }

	}

    void ActivateTree()
    {
        timeStartedGrowing = Time.time;
        transform.localScale = startingScale;
        status = TreeChopperController.Status.Growing;
        speed = Random.Range(0.00001f, 0.0005f);
        growthTime = Random.Range(growthTime * 0.75f, growthTime * 1.25f);
        gameObject.GetComponent<SpriteRenderer>().sprite = gameObject.GetComponentInParent<TreeSpawner>().GetSprite();
    }

    void DeactivateTree()
    {
        gameObject.SetActive(false);
    }
}
