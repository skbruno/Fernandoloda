using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class caiu : MonoBehaviour
{
    void OnCollisionEnter2D (Collision2D collision)
    {
        if(collision.gameObject.tag == "Player" )
        {
           GameController.instance.Gameoverr();
           Destroy(collision.gameObject);
        }

        if(collision.gameObject.tag == "morreu" )
        {
           Destroy(collision.gameObject);
        }  
    }

    void OnTriggerEnter2D (Collider2D collider)
    {
        if(collider.gameObject.layer == 8 )
        {
           Destroy(collider.gameObject);
        }
    }
}
