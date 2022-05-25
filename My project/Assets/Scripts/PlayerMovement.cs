using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;

    public float speed = 10f;

    public float vertical =0f;
    public float horizontal=0f;

    Vector3 moveDirection;

    

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal")* speed * Time.deltaTime;
        float vertical = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        moveDirection = new Vector3(horizontal, 0, vertical).normalized;
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + transform.TransformDirection(moveDirection));
    }
}
