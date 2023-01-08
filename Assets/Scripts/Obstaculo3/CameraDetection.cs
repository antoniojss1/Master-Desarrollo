using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDetection : MonoBehaviour
{
    private Transform cameraLens;
    private string playerTag = "Player";
    [SerializeField] private Material searching, spotted;

    //Sound
    [SerializeField] AudioSource alarmSound;

    // Start is called before the first frame update
    void Start()
    {
        cameraLens = transform.parent.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == playerTag)
        {
            Vector3 direction = other.transform.position - cameraLens.position;
            RaycastHit hit;
            if (Physics.Raycast(cameraLens.transform.position, direction.normalized, out hit, 1000))
            {
                //Debug.Log("Colisionando con " +hit.collider.name);
                if (hit.collider.gameObject.tag == playerTag)
                {
                    cameraLens.GetComponentInParent<MeshRenderer>().material = spotted;
                    //Debug.Log("Detectando player");
                    transform.parent.parent.GetComponent<CameraRotation>().PlayerSpotted();
                    if (!alarmSound.isPlaying)
                        alarmSound.Play();
                }
                else
                {
                    cameraLens.GetComponentInParent<MeshRenderer>().material = searching;
                    transform.parent.parent.GetComponent<CameraRotation>().PlayerNotDetected();
                    alarmSound.Stop();
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == playerTag)
        {
            cameraLens.GetComponentInParent<MeshRenderer>().material = searching;
            transform.parent.parent.GetComponent<CameraRotation>().PlayerNotDetected();
            alarmSound.Stop();
        }
    }

    public void playerTeleportedToRespawn()
    {
        cameraLens.GetComponentInParent<MeshRenderer>().material = searching;
        transform.parent.parent.GetComponent<CameraRotation>().PlayerNotDetected();
        alarmSound.Stop();
    }
}
