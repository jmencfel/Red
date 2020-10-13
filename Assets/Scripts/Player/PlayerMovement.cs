using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] Rigidbody body;
    [SerializeField] PlayerJump playerJump;
    [SerializeField] Transform fallCheck;

    [Header("Settings")]
    [SerializeField] float movementSpeed = 10.0f;
    private Vector2 movement;

    // Update is called once per frame
    void Update()
    {
        GetInput();
    }
    private void FixedUpdate()
    {
         Move();
    }
    private void GetInput()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }
    private void Move()
    {       
       Vector3 direction = transform.forward * movementSpeed * movement.y + transform.right * movementSpeed * movement.x;
       if (CheckStepPossible(direction * 0.3f))
          body.MovePosition(transform.position + direction * Time.deltaTime);       
    }
    private bool CheckStepPossible(Vector3 dir)
    {
        if (!playerJump.IsGrounded)
            return true;

        dir.y = -1.0f;
        fallCheck.position = transform.position + dir;
        if (Physics.CheckSphere(fallCheck.position, 0.3f))
        {
            Debug.DrawRay(fallCheck.position, transform.up * 1.0f, Color.yellow);
            return true;
        }
        return false;
    }
}
