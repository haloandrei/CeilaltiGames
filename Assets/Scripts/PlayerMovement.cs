using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController2D))]
public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;

    float runSpeed = 40f;

    float horizontalMove = 0f;
    bool jump = false;
    
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        if(Input.GetButtonDown("Jump"))
		{
            jump = true;
		}
    }

	private void FixedUpdate()
	{
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
	}
}
