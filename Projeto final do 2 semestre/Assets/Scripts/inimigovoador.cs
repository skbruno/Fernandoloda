﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inimigovoador : MonoBehaviour
{
    void OnCollisionEnter2D (Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            GameController.instance.Gameoverr();
            Destroy(other.gameObject);
        }
    }
}
