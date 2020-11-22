using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Woodsdown : MonoBehaviour
{
    
    public float timerdown;

    private TargetJoint2D target;
    private BoxCollider2D box;

    
    // Start is called before the first frame update
    void Start()
    {

        target = GetComponent<TargetJoint2D>();
        box = GetComponent <BoxCollider2D>();
        
    }

    // Update is called once per frame
    void OnCollisionEnter2D (Collision2D other)
    {
         if(other.gameObject.tag == "Player")
         {

             Invoke ("Voando", timerdown);


         }  
    }


    void Voando()
    {
        target.enabled = false;
        box.isTrigger = true;


    }


}
