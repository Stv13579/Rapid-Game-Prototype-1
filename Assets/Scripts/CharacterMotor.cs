using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMotor : MonoBehaviour
{
    public CharacterController controller;
    private float MovementSpeed = 0.5f;
    private Vector3 Velo;
    private bool BoolJump;

    // Update is called once per frame
    void Update()
    {
        Velo.x = Input.GetAxis("Horizontal") * MovementSpeed;
        if (Input.GetButtonDown("Jump"))
        {
            BoolJump = true;
        }
    }

    void FixedUpdate()
    {
        controller.Move(Velo);
        BoolJump = false;
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        
    }
}
