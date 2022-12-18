using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle2Movement : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    [SerializeField] private float speed = 1.5f;
    private int waypointIndex = 0;

    //Sound
    [SerializeField] AudioSource platformSound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movePlatform();
    }

    void movePlatform()
    {
        if (waypointIndex == 0)
        {
            transform.position = waypoints[waypointIndex].transform.position;
            waypointIndex++;
        }

        transform.position = Vector3.MoveTowards(transform.position, waypoints[waypointIndex].transform.position, speed * Time.deltaTime);
        if (!platformSound.isPlaying)
            platformSound.Play();

        if (Vector3.Distance(transform.position, waypoints[waypointIndex].transform.position) < 0.1f)
        {
            waypointIndex++;
            if (waypointIndex >= waypoints.Length)
                waypointIndex = 0;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.transform.SetParent(transform);
    }

    private void OnCollisionExit(Collision collision)
    {
        collision.gameObject.transform.SetParent(null);
    }
}
