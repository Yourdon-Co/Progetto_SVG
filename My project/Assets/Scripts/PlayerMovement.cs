using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;

    public float speedHorizontl = 10f;
    public float speedVertical = 5f;

    public float vertical =0f;
    public float horizontal=0f;

    Vector3 moveDirection;

    

    // Update is called once per frame
    void Update()
    {
         horizontal =Input.GetAxis("Horizontal")* speedHorizontl * Time.deltaTime;
         vertical = Input.GetAxis("Vertical") * speedVertical * Time.deltaTime;
        moveDirection = new Vector3(horizontal, 0, vertical);
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + transform.TransformDirection(moveDirection));
    }
}
