using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerLook : MonoBehaviour
{

    private PlayerInput _lookInput;
    private InputAction _accionMirar;

    [SerializeField] float minViewDistance = 25f;
    [SerializeField] Transform playerBody;


    public float sensibilidadMirada = 100f;
    float xRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        _lookInput = GetComponent<PlayerInput>();
        _accionMirar = _lookInput.actions["Mirar"];
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = _accionMirar.ReadValue<Vector2>().x * sensibilidadMirada * Time.deltaTime;
        float mouseY = _accionMirar.ReadValue<Vector2>().y * sensibilidadMirada * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -45, 45);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        playerBody.transform.Rotate(Vector3.up * mouseX);
    }
}
