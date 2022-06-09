using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField]
    GameObject attackPoint;

    [SerializeField]
    GameObject bullet;

    
    // Start is called before the first frame update
    void Start()
    {
        attackPoint.GetComponent<MeshRenderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Debug.Log("Mouse 0");
            GameObject CurrentBullet = Instantiate(bullet, attackPoint.GetComponent<Transform>().position + new Vector3(0, 0, 0.5f), attackPoint.GetComponent<Transform>().rotation);

        }
    }
}