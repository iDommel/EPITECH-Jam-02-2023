using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimAndShoot : MonoBehaviour
{
    private float timeSinceShoot = 0;
    private int nbrOfBalls = 6;
    public GameObject bullet;
    public GameObject[] myBullet;
    private Vector3 offset = new Vector3(0.5f, 0.5f, 0);
    private AudioSource m_AudioSource;

    void Start()
    {
        m_AudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PauseMenu.isPaused)
            return;
        // look at the mouse
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 10;
        Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);
        mousePos.x = mousePos.x - objectPos.x;
        mousePos.y = mousePos.y - objectPos.y;
        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        timeSinceShoot += Time.deltaTime;
        // timeSinceShoot += 1;

        if (Input.GetKey(KeyCode.Mouse1) && timeSinceShoot > 0.5f && nbrOfBalls > 0)
        {
            nbrOfBalls -= 1;
            m_AudioSource.Play();
            myBullet[nbrOfBalls].SetActive(false);
            timeSinceShoot = 0;
            GameObject bulletInstance = Instantiate(bullet, transform.position + offset, Quaternion.identity);
            bulletInstance.SetActive(true); // Has to delete
            Vector2 direction = new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y);
            direction.Normalize();
            bulletInstance.GetComponent<Rigidbody2D>().velocity = direction * 15;
        }

        if (nbrOfBalls == 0 && timeSinceShoot > 3f)
        {
            nbrOfBalls = 6;
            timeSinceShoot = 0;
            for (int i = 0; i < myBullet.Length; i++)
            {
                myBullet[i].SetActive(true);
            }
        }
    }
}
