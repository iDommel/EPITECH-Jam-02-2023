using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Ennemy") {
            other.gameObject.GetComponent<Animator>().SetBool("IsHit" , true);
            Destroy(gameObject);
            // Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }
}
