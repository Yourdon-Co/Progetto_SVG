using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollisionDash : MonoBehaviour
{

    public float initialSpeed;
    public GameObject enemy;
    public CoinCounter coinCounter;
    // Start is called before the first frame update
    void Start()
    {
        initialSpeed = enemy.GetComponent<AIEnemy>().getSpeed();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        int dashDamage = 30;

        if (enemy.GetComponent<AIEnemy>().getSpeed() > initialSpeed)
        {
            if (collision.gameObject.name == "Player 1")
            {

                PlayerHealth playerLife = collision.gameObject.GetComponent<PlayerHealth>();
                if (playerLife != null)
                {
                    playerLife.decreaseHealth(dashDamage);
                }

                //se è attivo lo scudo
                if (collision.gameObject.name == "Shield")
                {
                    Destroy(collision.gameObject);
                }
                if (coinCounter.numberCoin > 0)
                {
                    coinCounter.loseCoinOnDash(coinCounter.numberCoin / 2, collision.gameObject);//cosi perderà sempre la meta delle monete che ha
                }
            }
            else
                Debug.Log("Non hai colpito il player");

        }
    }
}
