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
        if (name == "Sleigh")
        {
            if (gameObject.tag == "Toy")
            {
                SleighRideController.controller.toyCatchSound.audio.Play();
                SleighRideController.controller.toysSaved++;
            }
            else
            {
                SleighRideController.controller.snowmanCrush.audio.Play();
                SleighRideController.controller.score -= 10;
                SleighRideController.controller.snowmanHits--;
            }
        }
        else if (name == "Floor")
        {
            SleighRideController.controller.hitGroundSound.audio.Play();
            SleighRideController.controller.toysDestroyed++;
        }
        gameObject.SetActive(false);
    }
}
