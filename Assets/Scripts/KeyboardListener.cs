using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardListener : MonoBehaviour
{
    public float speed = 10.0f;

    private Rigidbody2D rigidbodyname;

    private void Start()
    {
        rigidbodyname = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector2 velocity = new Vector2(horizontal, vertical) * speed;

        rigidbodyname.velocity = velocity;
    }
}