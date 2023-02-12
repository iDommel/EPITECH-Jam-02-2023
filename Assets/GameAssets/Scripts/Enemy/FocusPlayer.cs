using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocusPlayer : MonoBehaviour
{
    public Rigidbody2D enemyRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player") {
            // Get the player's position
            Vector3 playerPosition = other.gameObject.transform.position;

            // Get the enemy's position
            Vector3 enemyPosition = gameObject.transform.position;

            // Get the direction to the player
            Vector3 directionToPlayer = playerPosition - enemyPosition;

            // Move the enemy towards the player
            enemyRigidbody.velocity = directionToPlayer.normalized * 2f;
        }
    }
}
