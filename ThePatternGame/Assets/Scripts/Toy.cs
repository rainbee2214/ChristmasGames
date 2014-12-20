using UnityEngine;
using System.Collections;

public class Toy : MonoBehaviour 
{

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Collidable") Reset(other.gameObject.name);
    }

    public void Reset(string name)
    {
        if (name == "Sleigh") SleighRideController.controller.toyCatchSound.audio.Play();
        else if (name == "Floor") SleighRideController.controller.hitGroundSound.audio.Play();
        gameObject.SetActive(false);
    }
}
