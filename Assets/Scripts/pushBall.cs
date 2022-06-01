using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pushBall : MonoBehaviour
{

    public Rigidbody2D rb2;
    public bool left;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Respawn" && left == true)
        {
            rb2.velocity = new Vector2(-10, 0);
        }
        else if(collision.tag == "Respawn" && left == false)
        {
            rb2.velocity = new Vector2(10, 0);
        }
    }
}
