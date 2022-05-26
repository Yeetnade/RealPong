using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody2D rb2;
    public float speed;

    private void Awake()
    {
        rb2 = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        ResetPosition();
        AddStartingForce();
    }
    public void AddStartingForce()
    {
        float x = Random.value < 0.5f ? -1.0f : 1.0f;
        float y = Random.value < 0.5f ? Random.Range(-3.0f, -0.5f) : Random.Range(0.5f, 3.0f);

        Vector2 direction = new Vector2(x, y);
        GetComponent<Rigidbody2D>().velocity = direction * this.speed;

    }

    public void AddForce(Vector2 force)
    {
        rb2.AddForce(force);
    }

    public void ResetPosition()
    {
        rb2.position = Vector3.zero;
        rb2.velocity = Vector3.zero;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.name == "PaddleLeft")
        {
            float y = hitFactor(transform.position, col.transform.position, col.collider.bounds.size.y);
            Vector2 direction = new Vector2(0.0001f, y).normalized;
            GetComponent<Rigidbody2D>().velocity = direction * speed;
        }
        if (col.gameObject.name == "PaddleRight")
        {
            float y = hitFactor(transform.position, col.transform.position, col.collider.bounds.size.y);
            Vector2 direction = new Vector2(-0.0001f, y).normalized;
            GetComponent<Rigidbody2D>().velocity = direction * speed;
        }
    }

    float hitFactor(Vector2 ballpos, Vector2 racketPos, float racketHeight)
    {
        return (ballpos.y - racketPos.y) / racketHeight;
    }
}
