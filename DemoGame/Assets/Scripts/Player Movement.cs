using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float movementSpeed = 6f;
    [SerializeField]float jumpForce = 5f;
    public float jumpCooldown = 1.0f;
    private float nextJumpTime = 0f;
    private bool isJumping = false;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
       float horizontalInput = Input.GetAxis("Horizontal");
       float verticalInput = Input.GetAxis("Vertical");
       
       rb.velocity = new Vector3(horizontalInput * movementSpeed, rb.velocity.y, verticalInput * movementSpeed);
       
       //if (Input.GetButtonDown("Jump"))
       {
            
       }

       if (Input.GetButtonDown("Jump") && Time.time >= nextJumpTime)
       {
        Jump();
        nextJumpTime = Time.time + jumpCooldown;
       }
    }
    void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
        
        isJumping = true;

        nextJumpTime = Time.time + jumpCooldown;

        rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
    }

    void EndJump()
    {
        isJumping = false;
    }
}
