using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private PlayerInput _playerInput;
    private InputAction _accionAndar;
    private InputAction _accionSaltar;

    [SerializeField] float walkSpeed = 5f;
    [SerializeField] float jumpPower = 1f;

    private bool _groundedPlayer;

    Vector2 moveInput;
    Rigidbody myRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();

        _playerInput = GetComponent<PlayerInput>();
        _accionAndar = _playerInput.actions["Andar"];
        _accionSaltar = _playerInput.actions["Saltar"];
    }

    // Update is called once per frame
    void Update()
    {
        Run();


        if (_accionSaltar.ReadValue<float>() > 0)
        {
            if (isGrounded()) 
            {
                Jump();
            }
        }
        
    }

    void Run()
    {
        Vector3 playerVelocity = new Vector3(_accionAndar.ReadValue<Vector2>().x * walkSpeed, myRigidbody.velocity.y, _accionAndar.ReadValue<Vector2>().y * walkSpeed);
        myRigidbody.velocity = transform.TransformDirection(playerVelocity);
    }

    void Jump()
    {
        myRigidbody.AddForce(new Vector3(0, jumpPower, 0), ForceMode.Impulse);
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    bool isGrounded() 
    {
        return myRigidbody.velocity.y == 0;
        //Physics.CheckSphere(groundCheck.position, .1f)
    }

}
