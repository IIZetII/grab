using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour

{
    public Vector2 startPos;
    public Rigidbody2D rb;
    public float moveVector;
    public float speed;
    public int returnDistance;
    public bool move;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPos = transform.position;

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "player")
            collision.transform.parent = null;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            collision.transform.parent = transform;

        }
    }
    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(startPos, rb.position);
        if (returnDistance == Mathf.Round(distance)) move = false;
        if (distance <= 0) move = true;
        if (move)
        { 
            moveVector = 1 * speed;
            Vector2 move = rb.velocity;
            move.x = moveVector;
            rb.velocity = move;
        }
        else
        {
            moveVector = -1 * speed;
            Vector2 move = rb.velocity;
            move.x = moveVector;
            rb.velocity = move;
        }
    }
}
