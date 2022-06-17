using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Shooting : MonoBehaviour
{
    [SerializeField]
    GameObject attackPoint;

    [SerializeField]
    GameObject bullet;

    public Button shootButton;
    private Button btn;


    // Start is called before the first frame update
    void Start()
    {
        btn = shootButton.GetComponent<Button>();
        attackPoint.GetComponent<MeshRenderer>().enabled = false;
        btn.onClick.AddListener(ShootFuction);
    }

    // Update is called once per frame
    void Update()
    {
        //btn.onClick.AddListener(ShootFuction);
        //btn.onClick.RemoveAllListeners();
    }
    void ShootFuction()
    {
        Debug.Log("Mouse 0");
        GameObject CurrentBullet = Instantiate(bullet, attackPoint.GetComponent<Transform>().position + new Vector3(0, 0, 0.5f), attackPoint.GetComponent<Transform>().rotation);
    }
}