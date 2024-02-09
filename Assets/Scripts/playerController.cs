using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public float gravity; 
    public float jumpForce;

    private float _fallVelocity = 0;
    private CharacterController _CharacterController;
    void Start()
    {
        _CharacterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _CharacterController.isGrounded)
            _fallVelocity = -jumpForce;
    }


    void FixedUpdate()
    {
        _fallVelocity += gravity * Time.deltaTime;
        _CharacterController.Move(Vector3.down * Time.deltaTime * _fallVelocity);
    }
}
