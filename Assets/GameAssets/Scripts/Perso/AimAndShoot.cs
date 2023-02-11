using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimAndShoot : MonoBehaviour
{
    private float timeSinceShoot = 11;
    public GameObject bullet;
    private Vector3 offset = new Vector3(0.5f, 0.5f, 0);

    // Update is called once per frame
    void Update()
    {
        // look at the mouse
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 10;
        Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);
        mousePos.x = mousePos.x - objectPos.x;
        mousePos.y = mousePos.y - objectPos.y;
        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        timeSinceShoot += Time.deltaTime;

        if (Input.GetKey(KeyCode.Mouse1) && timeSinceShoot > 10)
        {
            timeSinceShoot = 0;
            GameObject bulletInstance = Instantiate(bullet, transform.position + offset, Quaternion.identity);
            bulletInstance.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 10);
            bulletInstance.SetActive(true); // Has to delete
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            Vector2 direction = new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y);
            direction.Normalize();
            bulletInstance.GetComponent<Rigidbody2D>().velocity = direction * 10;
        }
    }
}
