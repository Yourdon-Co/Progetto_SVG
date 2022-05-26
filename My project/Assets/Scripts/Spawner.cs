using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //alcuni attributi sono pubblici in modo tale da modificarli direttamente in Unity

    public GameObject objectToSpawn;
    private GameObject[] objectSpawned;
    private bool stopSpawning = false;
    public float spawnTime;
    public float spawnRepeatRate;
    public int limit;


   
    // Start is called before the first frame update
    void Start()
    {

        //Questa funzione permette di richiamare la funzione di spwan(SpawnObject) ogni volta che viene istanziato
        //un nuovo oggetto(coin/power-up) rispettando i tempi passati come parametro: 
        //Richiama il metodo SpawnObject in spawnTime secondi, quindi ripetutamente ogni spawnRepeat secondi
        InvokeRepeating("SpawnObject", spawnTime, spawnRepeatRate);
    }


    //Questa funzione permette di spawnare un nuovo oggetto(coin/power-up) in una posizione casuale, ed � possibile 
    //definire il numero massimo di oggetti da far spawnare, cambiando la variabile limit
    //il numero di oggetti presenti sar� calcolato mediante FindGameObjectsWithTag(tag),che
    //crea un vettore di oggetti che hanno il tag indicato(nel nostro caso tag: coin o powerUp)
    void SpawnObject()
    {
        objectSpawned = GameObject.FindGameObjectsWithTag(objectToSpawn.tag);
        if (objectSpawned.Length >= limit)
        {
            stopSpawning = true;
        }

        if (stopSpawning)
        {
            CancelInvoke("SpawnObject");
        }
        else
        {
            float planetRadius = (GetComponent<Transform>().localScale.x) / 2;
            Vector3 position = Random.insideUnitSphere * planetRadius;
            //Quaternion.identity permette di far spawnare l'oggettto perpendicolare al piante, ossia con la giusta rotazione
            Instantiate(objectToSpawn, position, Quaternion.identity);        
        }
    }

}


//si potrebbe aggiungere che nel momento in cui viene raccolto un oggetto ne compare un altro(questo per� solo per le monete)
