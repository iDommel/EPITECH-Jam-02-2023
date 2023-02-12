using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public GameObject[] waypoints;
    public float speed = 0.04f;
    int currentWP = 0;
    void Start()
    {
    }
    // void FixedUpdate()
    // {
    //     if (Vector2.Distance(waypoints[currentWP].transform.position,
    //                          transform.position) < 0.1f)
    //         currentWP = (currentWP + 1) % waypoints.Length;


    //     // this.transform.LookAt(waypoints[currentWP].transform.position);
    //     // this.transform.Translate(0, Time.deltaTime * speed, 0);
    //     Vector2 p = Vector2.MoveTowards(transform.position,
    //                                     waypoints[currentWP].transform.position,
    //                                     speed);
    //     GetComponent<Rigidbody2D>().MovePosition(p);

    //     Vector2 direction = waypoints[currentWP].transform.position - transform.position;
    //     GetComponent<Rigidbody2D>().velocity = direction.normalized * speed;

    //     GetComponent<Rigidbody2D>().MovePosition(this.transform.position);
    //     // GetComponent<Rigidbody2D>().MoveRotation(this.transform.rotation.z);
    // }

    void FixedUpdate()
    {
        if (waypoints.Length == 0)
            return;
        Vector3 p = Vector3.MoveTowards(transform.position,
                                            waypoints[currentWP].transform.position,
                                            speed);
        GetComponent<Rigidbody2D>().MovePosition(p);

        Vector3 direction = waypoints[currentWP].transform.position - transform.position;
        transform.rotation = Quaternion.LookRotation(Vector3.forward, direction);

        if (Vector3.Distance(transform.position, waypoints[currentWP].transform.position) < 0.1f)
        {
            currentWP = (currentWP + 1) % waypoints.Length;
        }
    }

}
