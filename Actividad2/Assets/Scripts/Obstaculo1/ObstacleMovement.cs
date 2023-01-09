using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    [SerializeField] private float speed = 2;
    private int waypointIndex = 0;

    //To stay in position
    private bool moveNext = true;
    [SerializeField] float timeToNext = 1.0f;

    //Sound
    [SerializeField] AudioSource elevatorSound;

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
        if (moveNext)
        {
            transform.position = Vector3.MoveTowards(transform.position, waypoints[waypointIndex].transform.position, speed * Time.deltaTime);
            if (!elevatorSound.isPlaying)
                elevatorSound.Play();
        }
        else
        {
            elevatorSound.Stop();
        }

        if (Vector3.Distance(transform.position, waypoints[waypointIndex].transform.position) < 0.1f)
        {
            StartCoroutine(TimeMove());
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

    //Waiting coroutine
    IEnumerator TimeMove()
    {
        moveNext = false;                               //Before time passing
        yield return new WaitForSeconds(timeToNext);
        moveNext = true;                                //After time passing
    }
}
