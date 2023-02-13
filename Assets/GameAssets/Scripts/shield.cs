using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class shield : MonoBehaviour
{
    public GameObject imgback;
    private bool isActi = false;
    private float time = 0;

    void Update() {
        if (isActi) {
            time += Time.deltaTime;
            if (time > 5) {
                SceneManager.LoadScene("MainMenu");
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") {
            imgback.SetActive(true);
            isActi = true;
            collision.gameObject.SetActive(false);
        }
    }
}
