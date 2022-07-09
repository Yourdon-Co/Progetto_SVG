using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIEnemy : MonoBehaviour
{
    //dash
    public float initialSpeed;
    private float time = 5f;

    //shooting
    [SerializeField]
    GameObject attackPoint;
    [SerializeField]
    GameObject bullet;

    [SerializeField]
    private int maxBullet = 10;

    //movimento
    [SerializeField]
    private float speedVertical = 10f;
    [SerializeField]
    private float rotationSpeed = 10f;

    private float rotation;
    private Rigidbody rb;


    public float getSpeed()
    {
        return speedVertical;
    }

    public void setSpeed(float newSpeed)
    {
        speedVertical = newSpeed;
    }

    public float getRoation()
    {
        return rotation;
    }

    public void setRotation(float newRotation)//compreso tra 1 e -1
    {
        rotation = newRotation;
    }

    // Start is called before the first frame update
    void Start()
    {
        initialSpeed = getSpeed();
        rb = GetComponent<Rigidbody>();

        InvokeRepeating("RandomRotation", 0.3f, 1f);
        InvokeRepeating("DashFunction", 4f, 15f);
        InvokeRepeating("ShootFuction", 6f, 10f);
    }

    void Update()
    {

    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + transform.forward * speedVertical * Time.fixedDeltaTime);
        Vector3 yRotation = Vector3.up * rotation * rotationSpeed * Time.fixedDeltaTime;
        Quaternion deltaRotation = Quaternion.Euler(yRotation);
        Quaternion targetRotation = rb.rotation * deltaRotation;
        rb.MoveRotation(Quaternion.Slerp(rb.rotation, targetRotation, 50f * Time.deltaTime));
        transform.Rotate(0f, rotation * rotationSpeed * Time.fixedDeltaTime, 0f, Space.Self);

    }

    
    public void RandomRotation()
    {
        setRotation(Random.Range(-1, 1));
    }
    /*
    public void RandomShooting()
    {
        Invoke("ShootFuction", 2f);
    }
    public void RandomDash()
    {
        Invoke("DashFunction", 15f);
    }
    */

    void ResetSpeed()
    {
        setSpeed(initialSpeed);
        Debug.Log("Dash resettato");

    }
    public void DashFunction()
    {
        setSpeed(initialSpeed * 2);
        Debug.Log("Dash partito");
        Invoke("ResetSpeed", time);

    }

    public void ShootFuction()
    {
        if (maxBullet > 0)
        {
            GameObject CurrentBullet = Instantiate(bullet, attackPoint.GetComponent<Transform>().position + new Vector3(0, 0, 0.5f), attackPoint.GetComponent<Transform>().rotation);
            maxBullet--;
           
        }
    }
}
