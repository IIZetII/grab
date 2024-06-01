using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.tag + 2);
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log(collision.gameObject.tag);
            collision.GetComponent<Enemy>().TakeDamage(1);
            Destroy(this.gameObject);
        }
    }
}