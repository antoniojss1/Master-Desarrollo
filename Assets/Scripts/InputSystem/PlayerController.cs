using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private PlayerInput _playerInput;
    private InputAction _accionAndar;
    private InputAction _accionMirar;
    private InputAction _accionSaltar;
    private CharacterController _charController;
    private Vector3 movementVector;

    [SerializeField] private float speed = 15f;
    [SerializeField] private float sightSensitivity = 40f;
    [SerializeField] private float jumpPower = 3f;
    [SerializeField] private float gravityMult = 1f;

    private float _gravity = -9.81f;
    private float _velocity;

    private float xRotation;
    private Camera _mainCamera;
    // Start is called before the first frame update
    void Start()
    {
        _playerInput = GetComponent<PlayerInput>(); //Porque es un componente de la misma entidad (GameObject)
        _accionAndar = _playerInput.actions["Andar"];
        _accionMirar = _playerInput.actions["Mirar"];
        _accionSaltar = _playerInput.actions["Saltar"];
        this._charController = GetComponent<CharacterController>();
        this._mainCamera = GetComponentInChildren<Camera>(); //Buscar componente cámara dentro de objetos hijos (solo es el objeto Camera).
    }

    // Update is called once per frame
    void Update()
    {
        ApplyGravity();
        walkAction();
        lookAction();
        JumpAction();
    }

    //Cada funcionalidad con un método aparte
    private void walkAction()
    {
        movementVector = this.transform.right * _accionAndar.ReadValue<Vector2>().x + this.transform.forward * _accionAndar.ReadValue<Vector2>().y + this.transform.up * movementVector.y;
        this._charController.Move(movementVector * Time.deltaTime * this.speed);
    }

    private void lookAction()
    {
        float mouseX = _accionMirar.ReadValue<Vector2>().x * sightSensitivity * Time.deltaTime;
        float mouseY = _accionMirar.ReadValue<Vector2>().y * sightSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -45, 45);

        _mainCamera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);  

        this.transform.Rotate(Vector3.up * mouseX);                                 
    }

    private void JumpAction()
    {
        if (_accionSaltar.triggered && _charController.isGrounded)
        {
            _velocity += jumpPower;
        }
    }

    private void ApplyGravity()
    {
        if (_charController.isGrounded && _velocity < 0.0f)
        {
            _velocity = -1.0f;
        }
        else
        {
            _velocity += _gravity * gravityMult * Time.deltaTime;
        }
        movementVector.y = _velocity;
    }
}