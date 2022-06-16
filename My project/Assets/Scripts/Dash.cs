using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Dash : MonoBehaviour
{

    public PlayerMovement playerMovement;
    public float initialSpeed;

    public Button dashButton;
    private Button btn;

    // Start is called before the first frame update
    void Start()
    {
        btn = dashButton.GetComponent<Button>();
        initialSpeed = playerMovement.speedVertical;
        btn.onClick.AddListener(DashFunction);
    }

    // Update is called once per frame
    void Update()
    {
        //btn.onClick.AddListener(DashFunction);
    }
    void ResetSpeed()
    {
        playerMovement.speedVertical = initialSpeed;
        Debug.Log("Dash resettato");

    }

    void DashFunction()
    {
        playerMovement.speedVertical = initialSpeed * 2;
        Debug.Log("Dash partito");
        Invoke("ResetSpeed", 5.0f);

    }
}
