using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnball : MonoBehaviour
{
    [SerializeField]
    private float spawnInter = 2f;
    [SerializeField]
    private float spawnTime = 2f;

    public GameObject ball;
 
    // Use this for initialization
    void Start()
    {
        InvokeRepeating("Spawn", spawnTime, spawnInter);
    }
 
    void Spawn()
    {
        GameObject clone = Instantiate(ball, transform.position, transform.rotation);
    }
}
