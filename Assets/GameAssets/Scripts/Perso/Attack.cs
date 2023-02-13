using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
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

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ennemy" && Input.GetKeyDown(KeyCode.Mouse0))
        {
            m_AudioSource.Play();
            other.gameObject.GetComponent<AudioSource>().Play();
            Destroy(other.gameObject);
        }
    }
}
