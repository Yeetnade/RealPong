using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody2D rb2;
    public float speed;
    public AudioSource ballSource;
    public AudioClip paddleSound, paddleSound2;

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
        float y = Random.value < 0.5f ? Random.Range(-3, -0.5f) : Random.Range(0.5f, 3f);

        Vector2 direction = new Vector2(x, y);
        GetComponent<Rigidbody2D>().velocity = direction * this.speed;

    }

    public void AddForce(Vector2 force)
    {
        rb2.AddForce(force);
    }

    public void ResetPosition()
    {
        Vector3 ballPos = new Vector3(0, Random.Range(-4.8f, 4.8f), 0);

        rb2.position = ballPos;

        rb2.velocity = Vector3.zero;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        float angle = Random.value < 0.5 ? 0.00001f : 0.001f;
        float angle2 = Random.value < 0.5 ? -0.00001f : -0.001f;
        if(col.gameObject.name == "PaddleLeft")
        {
            float y = hitFactor(transform.position, col.transform.position, col.collider.bounds.size.y);
            Vector2 direction = new Vector2(angle, y).normalized;
            GetComponent<Rigidbody2D>().velocity = direction * speed;
            ballSource.PlayOneShot(paddleSound);
        }
        if (col.gameObject.name == "PaddleRight")
        {
            float y = hitFactor(transform.position, col.transform.position, col.collider.bounds.size.y);
            Vector2 direction = new Vector2(angle2, y).normalized;
            GetComponent<Rigidbody2D>().velocity = direction * speed;
            ballSource.PlayOneShot(paddleSound2);
        }
        
    }

    float hitFactor(Vector2 ballpos, Vector2 racketPos, float racketHeight)
    {
        return (ballpos.y - racketPos.y) / racketHeight;
    }
}
