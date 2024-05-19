using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;
using Debug = UnityEngine.Debug;

public class trap : MonoBehaviour

{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.tag + 2);
        if (collision.gameObject.tag == "player")
        { Debug.Log(collision.gameObject.tag);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

}
