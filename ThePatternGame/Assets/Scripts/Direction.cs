using UnityEngine;
using System.Collections;

public class Direction : MonoBehaviour
{
    bool left;
    bool none = false;
    float increment = 0.001f;
    Vector2 position;

    float xBound = 5f;
 
    void Start()
    {
        int d = Random.Range(0, 2);
        if (d == 0)
        {
            left = true;
        }
        else if (d == 1)
        {
            left = false;
        }
        else if (d == 2)
        {
            none = true;
        }
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
            if (left && position.x >= xBound) ChangeDirection();
            else if (!left && position.x <= -xBound) ChangeDirection();
        }
    }

    public void ChangeDirection()
    {
        left = !left;
    }
}

