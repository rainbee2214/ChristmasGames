using UnityEngine;
using System.Collections;

public class SleighController : MonoBehaviour 
{
    float speed = 0.0001f;
    float xBound = 5f;
    bool left = false;
    bool right = false;

    Vector2 position;
    Vector2 startingPosition;

	void Start () 
    {
	
	}
	
	void Update () 
    {
        if (right) MoveRight();
        else if (left) MoveLeft();
	}

    public void Left() { left = !left; }
    public void Right() { right = !right; }

    void MoveLeft()
    {
        position = transform.position;
        position.x -= 0.1f;
        if (position.x < -xBound) position.x = -xBound;
        MoveSleigh(position);
    }

    void MoveRight()
    {
        position = transform.position;
        position.x += 0.1f;
        if (position.x > xBound) position.x = xBound;
        MoveSleigh(position);
    }

    void MoveSleigh(Vector2 position)
    {
        transform.position = position;
    }
}
