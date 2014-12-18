using UnityEngine;
using System.Collections;

public class Rotation : MonoBehaviour
{
    int rotateUpperBound = 10;
    int rotateLowerBound = -10;
    float speed;

    void Start()
    {
         speed = (Random.Range(rotateLowerBound, rotateUpperBound));
    }

    void Update()
    {
        transform.Rotate(Vector3.forward * Time.deltaTime * speed);
    }
}
