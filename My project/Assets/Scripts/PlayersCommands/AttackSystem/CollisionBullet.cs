using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionBullet : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        int bulletDamage = 10;

        Debug.Log(collision.body);
        Debug.Log(collision.gameObject);
        Debug.Log(collision.articulationBody);

        if (collision.gameObject.name == "Enemy 1")
            Debug.Log("Hai colpito il nemico");
        else
            Debug.Log("Non hai colpito il nemico");

        EnemyLife enemyLife = collision.gameObject.GetComponent<EnemyLife>();
        if (enemyLife != null)
        {
            enemyLife.decreaseHealth(bulletDamage);
        }
        //se è attivo lo scudo
        if (collision.gameObject.name == "Shield")
        {
            //forse bisogna distruggere anche il bullet
            Destroy(collision.gameObject);
        }

    }
}
