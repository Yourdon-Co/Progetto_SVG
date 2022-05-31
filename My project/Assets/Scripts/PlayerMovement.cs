using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;

    public float speed = 10f;

    public float vertical = 0f;
    public float horizontal = 0f;

    Vector3 moveDirection;



    // Update is called once per frame
    void Update()
    {
        TouchMovement();
        vertical = 1 * speed * Time.deltaTime;
        moveDirection = new Vector3(horizontal, 0, vertical).normalized;
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + transform.TransformDirection(moveDirection));
    }

    private void TouchMovement()
    {
        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).position.x > Screen.width / 2)
            {
                horizontal = 1 * speed * Time.deltaTime;
            }
            else if (Input.GetTouch(0).position.x < Screen.width / 2)
            {
                horizontal = -1 * speed * Time.deltaTime;
            }
        }
    }
}

