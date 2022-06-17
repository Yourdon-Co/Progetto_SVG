using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rallenty : MonoBehaviour
{
    private GameObject[] enemies;
    private float time = 10f;
    private float initialSpeed;


    // Start is called before the first frame update
    void Start()
    {
        enemies = GameObject.FindGameObjectsWithTag("enemy");
        initialSpeed = enemies[0].GetComponent<EnemyMovement>().getSpeed();
    }

    // Update is called once per frame
    void ActiveRallenty()
    {

        for (int i=0; i<enemies.Length; i++)
        {

            enemies[i].GetComponent<EnemyMovement>().setSpeed(initialSpeed / 2);

        }
        Invoke("ResetSpeed", time);
    }

    //non passo come parametro initial speed se no poi non funziona invoke
    void ResetSpeed()
    {
        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].GetComponent<EnemyMovement>().setSpeed(initialSpeed);
        }
    }
}
