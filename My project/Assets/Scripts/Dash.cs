using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{

    public PlayerMovement playerMovement;
    public float initialSpeed;

    // Start is called before the first frame update
    void Start()
    {
        initialSpeed = playerMovement.speedVertical;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            
            playerMovement.speedVertical = initialSpeed * 2;
            Debug.Log("Dash partito");
            Invoke("ResetSpeed", 5.0f);
            
        }
    }
    void ResetSpeed()
    {
        playerMovement.speedVertical = initialSpeed;
        Debug.Log("Dash resettato");

    }
}
