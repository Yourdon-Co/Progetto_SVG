using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectCollector : MonoBehaviour
{
    [SerializeField]
    private CoinCounter coinCounter;
    [SerializeField]
    private Shield shield;
    [SerializeField]
    private PlayerHealth playerhealth;
    [SerializeField]
    private CollisionBullet collisionbullet;
    [SerializeField]
    private Button btn;
    private bool activated = false;


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
        //inizializzo le reference a runtime
        //btn = GameObject.Find("PowerUpButton").GetComponent<Button>();
    }

    //Questa funzione permette al momento della collisione con la moneta o con il powerUp di richiamare nel
    //caso della moneta una funzione che aumenta il numero di monete raccolte,il quale sar� presente nello script 
    //Coin Countere e nel caso del powerUp richiamer� una ipotetica funzione che modifica delle stats,
    //presente anche essa in un altro script.Quando avviene la collisione l'oggetto raccolto viene ditrutto.
    private void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "coin")
        {
            coinCounter.addCoin();
            Destroy(collisionInfo.collider.gameObject);
            coinCounter.DisplayCoin();
        }


        else if (collisionInfo.collider.tag == "shield")
        {
            //decidere se realizzare tanti tag di powerup quanti sono questi oppure trovare un altro modo tramite ID
            //realizzare una funzione che attivi il powerUp/ come  � stato fatto per coinCounter.Add
            if (activated == false)
            {
                Destroy(collisionInfo.collider.gameObject);
                activated = true;

                //poich� voglio cambiare l'immagine che ho come figlio del bottone e poich� GetChildComponent
                //usa DFS e quindi ritorna l'immagine del bottone creo un vettore e trovo il primo figlio
                //diverso dal padre
                Image buttonImage = btn.GetComponent<Image>();
                Image[] images = btn.GetComponentsInChildren<Image>();
                foreach (Image image in images)
                {
                    if (image != buttonImage)
                    {
                        image.sprite = collisionInfo.collider.gameObject.GetComponent<Image>().sprite; ;
                        image.color = new Color(255, 255, 255, 255);
                        break;
                    }
                }

                btn.gameObject.SetActive(true);
                btn.onClick.AddListener(ActiveShield);
                

            }
        }
        else if (collisionInfo.collider.tag == "health")
        {
            if (activated == false)
            {
                Destroy(collisionInfo.collider.gameObject);
                activated = true;

                Image buttonImage = btn.GetComponent<Image>();
                Image[] images = btn.GetComponentsInChildren<Image>();
                foreach (Image image in images)
                {
                    if (image != buttonImage)
                    {
                        image.sprite = collisionInfo.collider.gameObject.GetComponent<Image>().sprite; ;
                        break;
                    }
                }

                btn.gameObject.SetActive(true);

                btn.onClick.AddListener(incrementHealth);

            }
        }
        else if (collisionInfo.collider.tag == "boostDmg")
        {
            if (activated == false)
            {
                Destroy(collisionInfo.collider.gameObject);
                activated = true;

                Image buttonImage = btn.GetComponent<Image>();
                Image[] images = btn.GetComponentsInChildren<Image>();
                foreach (Image image in images)
                {
                    if (image != buttonImage)
                    {
                        image.sprite = collisionInfo.collider.gameObject.GetComponent<Image>().sprite; ;
                        break;
                    }
                }

                btn.gameObject.SetActive(true);

                btn.onClick.AddListener(boostBulletDamage);

            }
        }
    }

    void boostBulletDamage()
    {
        int newDamage = 33;
        collisionbullet.boostBulletDamage(newDamage);
        activated = false;
        btn.gameObject.SetActive(false);
    }

    void incrementHealth()
    {
        int healthPoints = 33;
        playerhealth.incrementHealth(healthPoints);
        activated = false;
        btn.gameObject.SetActive(false);

    }
    void ActiveShield()
    {
        shield.ActiveShield();
        activated = false;
       btn.gameObject.SetActive(false);
    }
}