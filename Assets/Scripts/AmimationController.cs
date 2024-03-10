using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmimationController : MonoBehaviour
{
    // Start is called before the first frame update
    //CharacterController _CharacterController;
    Animator PlayerAnimator;
    void Start()
    {
         //_CharacterController = GetComponent<CharacterController>();
        PlayerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckControls();
        
    }

    private void CheckControls()
    {
        if (Input.GetKey(KeyCode.W))
        { PlayerAnimator.SetBool("isForw", true);}
        else { PlayerAnimator.SetBool("isForw", false); }

        if (Input.GetKey(KeyCode.A))
        { }

        if (Input.GetKey(KeyCode.S))
        { }

        if (Input.GetKey(KeyCode.D))
        { }

        // Jump
        //if (Input.GetKeyDown(KeyCode.Space) && _CharacterController.isGrounded)
        //{ }
    }
}
