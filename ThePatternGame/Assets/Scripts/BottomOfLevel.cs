using UnityEngine;
using System.Collections;

public class BottomOfLevel : MonoBehaviour 
{
    void OnTriggerEnter2D(Collider2D other)
    {
        other.gameObject.SetActive(false);
        SnowflakesController.controller.UpdateHealth(-1f);
    }

}
