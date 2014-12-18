using UnityEngine;
using System.Collections;

public class Direction : MonoBehaviour
{
    bool left;
    bool none = false;
    float increment;
    float incrementLower = 0.001f;
    float incrementHigher = 0.003f;
    Vector2 position;

    float xBound = 3f;
 
    void Start()
    {
        int d = Random.Range(0, 2);
        switch(d)
        {
            case 0: left = true; break;
            case 1: left = false; break;
            default: none = true;  break;
        }
        increment = Random.Range(incrementLower, incrementHigher);
    }

    void Update()
    {
        position = transform.position;
        if (!none)
        {
            if (left)
            {
                position.x -= increment;
            }
            else
            {
                position.x += increment;
            }
            transform.position = position;
            if (left && position.x <= -xBound) ChangeDirection();
            else if (!left && position.x >= xBound) ChangeDirection();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        ChangeDirection();
    }
    public void ChangeDirection()
    {
        left = !left;
    }
}

