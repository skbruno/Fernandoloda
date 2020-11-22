using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moeda : MonoBehaviour
{
    [SerializeField]
    private GameObject release;

    
    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject, 0.035f);
            release.gameObject.SetActive (true);
        }
        
    }
}
