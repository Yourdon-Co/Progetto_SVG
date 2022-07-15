using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCollectorEnemy : MonoBehaviour
{
    [SerializeField]
    private CoinCounterEnemy coinCounterEnemy;
    [SerializeField]
    private Shield shield;
    [SerializeField]
    private EnemyLife enemyLife;
    [SerializeField]
    private EnemyCollisonBullet enemyCollisionbullet;



    //non si pu� utlizzare questa funzione poich� in quetso caso con la funzione trigger bisogna attivare is trigger
    //che disabilita la gravit� e se non ci fosse la gravit� le monete andrebbero a fanculo per questo come soluzione basta 
    //basta dimuire la massa dell'oggetto raccolto o aumentare quella della macchina chiaramente andando poi ad aumentare la
    //forza di gravit�

    /*private void OnTriggerEnter(Collider colliderInfo)
    {
        if (colliderInfo.tag == "coin")
        {
            coinCounter.addCoin();
            Destroy(colliderInfo.gameObject);
        }
            

        else if (colliderInfo.tag == "powerUp")
        {
            //realizzare una funzione che attivi il powerUp/ come  � stato fatto per coinCounter.Add
            Destroy(colliderInfo.gameObject);
        }
    }
    */

    private void Awake()
    {
       
    }

    //Questa funzione permette al momento della collisione con la moneta o con il powerUp di richiamare nel
    //caso della moneta una funzione che aumenta il numero di monete raccolte,il quale sar� presente nello script 
    //Coin Countere e nel caso del powerUp richiamer� una ipotetica funzione che modifica delle stats,
    //presente anche essa in un altro script.Quando avviene la collisione l'oggetto raccolto viene ditrutto.
    private void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "coin")
        {
            Debug.Log("nemico raccolto moneta");
            coinCounterEnemy.addCoin();
            Destroy(collisionInfo.collider.gameObject);
        }


        else if (collisionInfo.collider.tag == "shield")
        {
            ActiveShield();
        }
        else if (collisionInfo.collider.tag == "health")
        {
            incrementHealth();
        }
        else if (collisionInfo.collider.tag == "boostDmg")
        {
            boostBulletDamage();
        }

    }
    void boostBulletDamage()
    {
        int newDamage = 33;
        enemyCollisionbullet.boostBulletDamage(newDamage);

    }

    void incrementHealth()
    {
        int healthPoints = 33;
        enemyLife.incrementHealth(healthPoints);
    }
    void ActiveShield()
    {
        shield.ActiveShield();
       
    }
}

