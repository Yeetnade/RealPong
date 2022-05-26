using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPaddles : MonoBehaviour
{
    public bool isPlayer1;
    public Rigidbody2D rb2;
    public float speed;
    private float movement;
    private void Awake()
    {
        rb2 = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(isPlayer1)
        {
            movement = Input.GetAxisRaw("Vertical");
        }
        else
        {
            movement = Input.GetAxisRaw("Vertical2");
        }

        rb2.velocity = new Vector2(rb2.velocity.x, movement * speed);
    }

    public void ResetPosition()
    {
        rb2.position = new Vector2(rb2.position.x, 0.0f);
        rb2.velocity = Vector2.zero;
    }
}
