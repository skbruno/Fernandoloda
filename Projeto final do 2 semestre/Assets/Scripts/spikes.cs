using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spikes : MonoBehaviour
{
    void OnCollisionEnter2D (Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
           GameController.instance.Gameoverr();
           Destroy(collision.gameObject);
        }
    }
}
