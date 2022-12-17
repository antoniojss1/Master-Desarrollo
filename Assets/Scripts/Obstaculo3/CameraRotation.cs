using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    [SerializeField] private float timeToWait = 1f;
    [SerializeField] private float angle = 90;
    [SerializeField] private float rotationSeconds = 3;
    private bool startNextRotation = true;
    [SerializeField] private bool rotateRight = true;
    private IEnumerator rotateCoroutine, catchCoroutine;
    private Quaternion initialRotation;
    private bool playerDetection = false;

    // Start is called before the first frame update
    void Start()
    {
        initialRotation = transform.rotation;
        SetUpStartRotation(initialRotation);
    }

    // Update is called once per frame
    void Update()
    {
        if (startNextRotation && rotateRight)
        {
            rotateCoroutine = Rotate(rotationSeconds, angle);
            StartCoroutine(rotateCoroutine);
        }
        else if (startNextRotation && !rotateRight)
        {
            rotateCoroutine = Rotate(rotationSeconds, -angle);
            StartCoroutine(rotateCoroutine);
        }
    }

    void SetUpStartRotation(Quaternion initialRotation)
    {
        if (rotateRight)
        {
            transform.rotation = initialRotation * Quaternion.AngleAxis(-angle/2, Vector3.up);
        }
        else
        {
            transform.rotation = initialRotation * Quaternion.AngleAxis(angle / 2, Vector3.up);
        }
    }

    public void PlayerSpotted()
    {
        if (!playerDetection)
        {
            playerDetection = true;
            StopCoroutine(rotateCoroutine);
            StartCoroutine(MoveWait(1f));
        }
    }

    public void PlayerNotDetected()
    {
        playerDetection = false;
    }

    IEnumerator Rotate(float duration, float angle)
    {
        startNextRotation = false;

        Quaternion initialRotation = transform.rotation;
        float timer = 0f;

        while (timer < duration)
        {
            timer += Time.deltaTime;
            transform.rotation = initialRotation * Quaternion.AngleAxis(timer / duration * angle, Vector3.up);
            yield return null;
        }

        yield return new WaitForSeconds(timeToWait);

        startNextRotation = true;
        rotateRight = !rotateRight;
    }

    IEnumerator MoveWait(float timeToWait)
    {
        catchCoroutine = CatchedPlayer();
        StartCoroutine(catchCoroutine);
        yield return new WaitForSeconds(timeToWait);
        if (playerDetection)
        {
            StartCoroutine(MoveWait(1f));                   //Personaje aun detectado, sigue esperando
        }
        else
        {
            StopCoroutine(catchCoroutine);                   //Se cancela el quitar vida por detectar personaje
            StartCoroutine(rotateCoroutine);                //Personaje ya no detectado, puede volver a moverse la camara
        }
    }

    IEnumerator CatchedPlayer()
    {
        if (playerDetection)
            yield return new WaitForSeconds(3f);                //Espera tres segundos si se detecta un jugador

        if (playerDetection)
        {
            //Si tras 3 segundos se sigue detectando jugador, quita vida
            Debug.Log("Vida perdida");
        }   
    }
}
