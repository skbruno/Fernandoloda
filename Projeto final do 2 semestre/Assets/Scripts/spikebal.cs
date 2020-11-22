using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spikebal : MonoBehaviour
{
    [SerializeField]
    private float speed = 2f;

    [SerializeField]
    private float movetime = 0.8f;

    private bool dirRight;

    private float timer;
    

    void Update()
    {
        if(dirRight)
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.down * speed * Time.deltaTime);
        }

        timer += Time.deltaTime;
        if(timer >= movetime)
        {
            dirRight = !dirRight;
            timer = 0f;
        }
    }
}
