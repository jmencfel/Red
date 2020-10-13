using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [Header("References")]
    [SerializeField] Rigidbody body;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask groundLayer;

    [Header("Settings")]
    [SerializeField] private float jumpForce = 5.0f;

    private bool shouldJump = false;
    private bool isGrounded = true;
    public bool IsGrounded { get { return isGrounded; } }
    private void Update()
    {
        if (!shouldJump)
            shouldJump = Input.GetKeyDown(KeyCode.Space);

        if(!isGrounded)
        isGrounded = Physics.CheckSphere(groundCheck.position, 0.1f, groundLayer);
    }
    private void FixedUpdate()
    {
        if(shouldJump && isGrounded)
        {
            isGrounded = false;
            shouldJump = false;
            body.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}
