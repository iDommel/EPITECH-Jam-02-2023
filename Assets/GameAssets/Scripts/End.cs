using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;

public class End : MonoBehaviour
{
    private AudioSource m_AudioSource;

    // Start is called before the first frame update
    void Start()
    {
        m_AudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    bool IsAllDead() {
        if (GameObject.FindGameObjectsWithTag("Ennemy").Length > 0) {
            return false;
        } else {
            return true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player" && IsAllDead()) {
            m_AudioSource.Play();
            // freeze player
            other.gameObject.GetComponent<move>().enabled = false;
            LoadNextLevel();
        }
    }

    async private void LoadNextLevel() {
        await Task.Delay(3000);
        SceneManager.LoadScene("LevelOneScene");
    }
}
