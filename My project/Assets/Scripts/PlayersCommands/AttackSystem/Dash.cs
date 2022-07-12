using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Dash : MonoBehaviour
{

    public GameObject player;
    public float initialSpeed;

    public Button dashButton;
    private Button btn;

    private float time = 5f;

    // Start is called before the first frame update

    private void Awake()
    {
        dashButton = GameObject.Find("DashButton").GetComponent<Button>();
    }

        void Start()
    {
        btn = dashButton.GetComponent<Button>();
        initialSpeed = player.GetComponent<PlayerMovement>().getSpeed();
        btn.onClick.AddListener(DashFunction);
    }

    // Update is called once per frame
    void Update()
    {
        //btn.onClick.AddListener(DashFunction);
    }
    void ResetSpeed()
    {
        player.GetComponent<PlayerMovement>().setSpeed(initialSpeed);
        Debug.Log("Dash resettato");

    }

    void DashFunction()
    {
        player.GetComponent<PlayerMovement>().setSpeed(initialSpeed * 2);
        Debug.Log("Dash partito");
        Invoke("ResetSpeed", time);

    }
}
