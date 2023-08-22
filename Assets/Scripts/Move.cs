using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private Rigidbody rb;
    private float distGround;
    [SerializeField] private float velocidad, FuerzaSalto;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        distGround = GetComponent<Collider>().bounds.extents.y;
    }

    void Update()
    {
        UpdateMover();
        UpdateSaltar();
    }

    private void UpdateMover(){
        Vector3 mover;
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        if(moveX != 0 || moveY !=0){
            mover = (transform.forward * moveY + transform.right * moveX).normalized * velocidad;
        }
        else{
            mover = Vector3.zero;
        }
        mover.y = rb.velocity.y;
        rb.velocity = mover;
    }
    private void UpdateSaltar(){
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            rb.AddForce(Vector3.up * FuerzaSalto, ForceMode.Impulse);
        }
    }
    private bool IsGrounded(){
        return Physics.BoxCast(transform.position, new Vector3(0.4f, 0f, 0.4f), Vector3.down, Quaternion.identity, distGround + 0.1f);
    }

}
