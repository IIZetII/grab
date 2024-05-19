using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sam : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    public float forceJump;
    public float moveVector;
    public bool groundStand;
    public float rayDistance;
    public bool doubleJump;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void FixedUpdate()
    {

    }

    void Update()
    {
        moveVector = Input.GetAxis("Horizontal") * speed * 10;
        Vector2 move = rb.velocity;
        move.x = moveVector;
        //transform.Translate(moveVector, 0, 0);
        rb.velocity = move;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (doubleJump && !groundStand)
            {
                rb.AddForce(transform.up * forceJump, ForceMode2D.Impulse);
                doubleJump = false;
            }
            if (groundStand)
            {
                rb.AddForce(transform.up * forceJump, ForceMode2D.Impulse);
                groundStand = false;
            }
        }
        
        
    }
    private void OnCollisionEnter2D(Collision2D hit)
    {
        if (hit.gameObject.tag == "YesDB")
        {
            groundStand = true;
            doubleJump = true;
        }
        if (hit.gameObject.tag == "NoDB")
        {
            groundStand = true;
            doubleJump = false;
        }
    }
}
