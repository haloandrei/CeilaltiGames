using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController2D))]
public class SchoolSubjectMovement : MonoBehaviour
{
    public float jumpRate = 0.01f;
    public float runSpeed = 20f;

    CharacterController2D controller;
    GameObject target;
    float horizontalMove = 0f;
    bool jump = false;

	private void Start()
	{
        controller = GetComponent<CharacterController2D>();
        target = GameObject.FindGameObjectWithTag("Player");
	}

	void Update()
    {
        horizontalMove = runSpeed * (target.transform.position.x - transform.position.x > 0 ? 1 : -1);

        if (Random.Range(0f, 1f) < jumpRate)
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
