using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] Rigidbody body;
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
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
    }
    private void Move()
    {
        body.MovePosition(transform.position + transform.forward * movementSpeed * movement.y * Time.deltaTime  +transform.right * movementSpeed * movement.x * Time.deltaTime);      
    }

}
