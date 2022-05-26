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
    [SerializeField]
    private float horizontal = 0f;

    private Vector3 moveDirection;



    // Update is called once per frame
    void Update()
    {
        float horizontal = 0 * speed * Time.deltaTime;
        float vertical = 1 * speed * Time.deltaTime;
        moveDirection = new Vector3(horizontal, 0, vertical).normalized;
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + transform.TransformDirection(moveDirection));
    }
}
