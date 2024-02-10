using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public float speed;
    public float gravity; 
    public float jumpForce;

    private float _fallVelocity = 0;
    private CharacterController _CharacterController;
    private Vector3 _moveVector;
    void Start()
    {
        _CharacterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Debug.Log($"{_CharacterController.isGrounded} {_fallVelocity}");
        //movement
        _moveVector = Vector3.zero;
            
        if (Input.GetKey(KeyCode.W))
            _moveVector += transform.forward;

        if (Input.GetKey(KeyCode.A))
            _moveVector -= transform.right;

        if (Input.GetKey(KeyCode.S))
            _moveVector -= transform.forward;

        if (Input.GetKey(KeyCode.D))
            _moveVector += transform.right;

        // Jump
        if (Input.GetKeyDown(KeyCode.Space) && _CharacterController.isGrounded)
            _fallVelocity = -jumpForce;
        




    }


    void FixedUpdate()
    {   
        //movement
        _CharacterController.Move(_moveVector * speed * Time.deltaTime );

        //gravity and Jump
         _fallVelocity += gravity * Time.deltaTime;
        _CharacterController.Move(Vector3.down * Time.deltaTime * _fallVelocity);

        if (_CharacterController.isGrounded)
            _fallVelocity = 0;
    }
}
