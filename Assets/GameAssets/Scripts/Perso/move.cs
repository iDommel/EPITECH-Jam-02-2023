using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class move : MonoBehaviour
{
    public float speed = 4f;

    void FixedUpdate()
    {
        //move
        if (Input.GetKey(KeyCode.Z)) {
            transform.Translate(Vector2.up * speed * Time.deltaTime);
        } 
        if (Input.GetKey(KeyCode.S)) {
            transform.Translate(Vector2.down * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.Q)) {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D)) {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ennemy")
        {
            SceneManager.LoadScene("LevelOneScene");
        }
    }
}
