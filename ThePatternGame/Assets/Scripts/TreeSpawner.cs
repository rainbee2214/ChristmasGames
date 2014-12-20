using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TreeSpawner : MonoBehaviour 
{
    int rows = TreeChopperController.rows;
    int columms = TreeChopperController.columns;
    List<Vector2> gridSpaces = new List<Vector2>();
    List<GameObject> trees;

    float horizontalGap = 3f;
    float verticalGap = 3.5f;

    List<Sprite> treeSprites = new List<Sprite>();

    public Sprite GetSprite()
    {
        return treeSprites[Random.Range(1, 19)];
    }

	void Start () 
    {
        GetTreeSprites();
        SetGridSpaces();        
        SpawnTrees();
	}
	
	void Update () 
    {
        CheckStats();
	}

    void CheckStats()
    {
        if (rows != TreeChopperController.rows) rows = TreeChopperController.rows;
        if (columms != TreeChopperController.columns) columms = TreeChopperController.columns;
    }

    void GetTreeSprites()
    {
        for (int i = 1; i <= 20; i++)
        {
            treeSprites.Add(Instantiate(Resources.Load("Sprites/Trees/christmastree" + i, typeof(Sprite))) as Sprite);
        }
    }

    void SpawnTrees()
    {
        if (trees == null) trees = new List<GameObject>();

        foreach (Vector2 position in gridSpaces)
        {  
            trees.Add(Instantiate(Resources.Load(("Trees/christmasTree"), typeof(GameObject)), position, Quaternion.identity) as GameObject);
        }

        for (int i = 0; i < trees.Count; i++)
        {
            trees[i].transform.parent = transform;
            trees[i].gameObject.GetComponent<SpriteRenderer>().sprite = GetSprite();
        }
    }

    void SetGridSpaces()
    {
        float startingX = (columms * horizontalGap / 2f) - horizontalGap/2;
        float startingY = (rows * verticalGap / 2f) - verticalGap/2;
        Debug.Log(startingX);
        Debug.Log(startingY);
        
        Vector2 position = new Vector2(-startingX, startingY);

        for (int i = 0; i < rows * columms; i++)
        {
            if (i != 0 && i % columms == 0)
            {
                position.y -= verticalGap;
                position.x = -startingX;
            }
            gridSpaces.Add(position);
            position.x += horizontalGap;
        }

    }
}
