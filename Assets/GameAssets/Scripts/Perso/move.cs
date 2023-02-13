using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;

public class move : MonoBehaviour
{
    public float speed = 4f;

    public AudioClip looseSound;
    public AudioClip startSound;

    private AudioSource m_AudioSource;
    private GameObject player;

    void Start()
    {
        m_AudioSource = GetComponent<AudioSource>();
        m_AudioSource.clip = startSound;
        m_AudioSource.Play();
        player = GameObject.Find("Player");
    }

    void FixedUpdate()
    {
        if (PauseMenu.isPaused)
            return;
        //move
        if (Input.GetKey(KeyCode.Z))
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector2.down * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
    }

    async void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ennemy")
        {
            m_AudioSource.clip = looseSound;
            m_AudioSource.Play();
            for (int i = 0; i < player.transform.childCount; i++)
            {
                GameObject child = player.transform.GetChild(i).gameObject;
                child.SetActive(false);
            }
            await Task.Delay(1000);
            SceneManager.LoadScene("LevelOneScene");
        }
    }
}
