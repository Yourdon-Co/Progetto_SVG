using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rb;
    [SerializeField]
    private float speed = 10f;

    [SerializeField]
    private float vertical = 0f;


    private Vector3 moveDirection;

    public float getSpeed()
    {
        return speed;
    }
    public void setSpeed(float newSpeed)
    {
        speed=newSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        vertical = 1 * speed * Time.deltaTime;
        moveDirection = new Vector3(0, 0, vertical).normalized;
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + transform.TransformDirection(moveDirection));
    }
}
