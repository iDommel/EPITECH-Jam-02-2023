using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class Hit : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Ennemy") {
            other.gameObject.GetComponent<Animator>().SetBool("IsHit" , true);
            other.gameObject.GetComponent<AudioSource>().Play();
            killEnnemy(other.gameObject);
            Destroy(gameObject);
        }

        if (other.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }

    async private void killEnnemy(GameObject ennemy) {
        
        await Task.Delay(500);
        Destroy(ennemy);
    }
}
