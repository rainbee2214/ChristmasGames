using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TreeSpawner : MonoBehaviour 
{
    int rows = TreeChopperController.rows;
    int columms = TreeChopperController.columns;
    List<Vector2> gridSpaces = new List<Vector2>();
    List<GameObject> trees;

    float horizontalGap = 3.5f;
    float verticalGap = 5f;

	void Start () 
    {
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

    void SpawnTrees()
    {
        if (trees == null) trees = new List<GameObject>();

        int i = 1;
        foreach (Vector2 position in gridSpaces)
        {  
            trees.Add
                (Instantiate(
                //Resources.Load(("Trees/christmasTree" + Random.Range(1, 20)), typeof(GameObject))
                Resources.Load(("Trees/christmasTree" + i), typeof(GameObject))
                , position
                , Quaternion.identity) as GameObject);
            
            i++;
            if (i >= 20) i = 1;
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

        //for (int i = 0; i < gridSpaces.Count; i++)
        //{
        //    Debug.Log(gridSpaces[i]);
        //}
    }
}
