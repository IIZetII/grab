using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Fall : MonoBehaviour
{
    public Rigidbody2D rb;
    public BoxCollider2D bk;
    public float second = 2;
    public float seconds = 15;
    public Vector2 startPos;
    void Start()
    {
        startPos = this.gameObject.transform.position;
        rb = GetComponent<Rigidbody2D>();
        bk = GetComponent<BoxCollider2D>();
    }
    IEnumerator TimedFall()
    {
        yield return new WaitForSeconds(second);
        rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
        bk.enabled = false;
        rb.AddForce(new Vector2(0, -1));
        StartCoroutine(ReturnToAxis());
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            StartCoroutine(TimedFall());

        }
    }
    IEnumerator ReturnToAxis()
    {
        yield return new WaitForSeconds(seconds);
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        bk.enabled = true;
        this.gameObject.transform.position = startPos;
    }
}
