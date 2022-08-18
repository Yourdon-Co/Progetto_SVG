using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollisonBullet : MonoBehaviour
{
    private int bulletDamage = 10;
    int initialbulletDamage;
    private float time = 5f;
    [SerializeField]
    //private GameObject enemy;//che sarà o il player o l'enemy

    public int getBulletDamage()
    {
        return bulletDamage;
    }
    public void setBulletDamage(int damage)
    {
        bulletDamage = damage;
    }


    void Start()
    {
        initialbulletDamage = bulletDamage;
    }
    private void OnCollisionEnter(Collision collision)
    {

        Debug.Log(collision.body);
        Debug.Log(collision.gameObject);
        Debug.Log(collision.articulationBody);

        if (collision.gameObject.name == "Player 1")
        {
            Debug.Log("Hai colpito il player");

            PlayerHealth playerLife = collision.gameObject.GetComponent<PlayerHealth>();
            if (playerLife != null)
            {
                playerLife.decreaseHealth(getBulletDamage());
            }
            //se è attivo lo scudo
            if (collision.gameObject.name == "Shield")
            {
                //forse bisogna distruggere anche il bullet
                Destroy(collision.gameObject);
            }
        }
        else
            Debug.Log("Non hai colpito il player");




    }

    public void boostBulletDamage(int newDamage)
    {
        setBulletDamage(newDamage);
        Debug.Log("Danno aumentato: " + newDamage);
        Invoke("ResetBoost", time);
    }

    public void ResetBoost()
    {
        setBulletDamage(initialbulletDamage);
        Debug.Log("Boost damage resettato");
    }
}
