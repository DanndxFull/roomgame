using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float moveSpeed, forceJump;
    //Speed 10 - Jump 7
    private Vector3 direction;
    [SerializeField] private LayerMask layer;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        direction = new Vector3(moveX, 0, moveY);

        Vector3 moveVector = transform.TransformDirection(direction) * moveSpeed;
        rb.velocity = new Vector3(moveVector.x, rb.velocity.y, moveVector.z);
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    public void Jump()
    {
        if (Physics.Raycast(transform.position, Vector3.down, 1.5f, layer))
        {
            rb.AddForce(Vector3.up * forceJump, ForceMode.Impulse);
        }
    }
}
