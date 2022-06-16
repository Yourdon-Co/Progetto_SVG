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
    Vector3 moveRotation;

    [SerializeField]
    public float rotationSpeed =0f;

    // Update is called once per frame
    void Update()
    {
        //horizontal =Input.GetAxis("Horizontal") * speedHorizontl * Time.deltaTime;
        TouchMovement();
        vertical = Input.GetAxis("Vertical") * speedVertical * Time.deltaTime;
        //vertical = 1 * speedVertical * Time.deltaTime;
        moveDirection = new Vector3(0, 0, vertical);
        moveRotation = new Vector3(horizontal, 0, 0);

        //moveDirection.Normalize();
        //moveRotation.Normalize();
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + transform.TransformDirection(moveDirection));
 

        if (moveRotation != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(moveRotation, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);

        }
    }

    void TouchMovement()
    {
        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).position.x > Screen.width / 2)
            {
                horizontal = 1 * speedHorizontl * Time.deltaTime;
            }
            if (Input.GetTouch(0).position.x < Screen.width / 2)
            {
                horizontal = -1 * speedHorizontl * Time.deltaTime;
            }
        }
    } 
}
