using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDash : MonoBehaviour
{

    public float initialSpeed;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        initialSpeed = player.GetComponent<PlayerMovement>().getSpeed();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        int dashDamage = 30;

        if (player.GetComponent<PlayerMovement>().getSpeed() > initialSpeed)
        {
            if (collision.gameObject.name == "Enemy 1")
                Debug.Log("Hai colpito il nemico");
            else
                Debug.Log("Non hai colpito il nemico");

            EnemyLife enemyLife = collision.gameObject.GetComponent<EnemyLife>();
            if (enemyLife != null)
            {
                enemyLife.decreaseHealth(dashDamage);
            }

            //se è attivo lo scudo
            if(collision.gameObject.name == "Shield")
            {
                Destroy(collision.gameObject);
            }
        }
    }
}
