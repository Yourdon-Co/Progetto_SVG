using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField]
    private float timeRemaining = 10;
    [SerializeField]
    private bool timerIsRunning = false;
    [SerializeField]
    private TextMeshProUGUI timeText;
    private void Start()
    {
        // Starts the timer automatically
        timerIsRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerIsRunning)
        {
            calculateTimeRemaining();
        }
    }

    //funzione che permette di calcolare il tempo rimanente sottraendo Time.deltaTime che dovrebbe ritornare i secondi che passano ogni frame
    private void calculateTimeRemaining()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            DisplayTime(timeRemaining);
        }
        else
        {
            Debug.Log("Time has run out!");
            timeRemaining = 0;
            timerIsRunning = false;
            //lanciare la funzione che chiama la schermata di fine partita che andrà creta in un ipotetico game manager
        }
    }

    //fuznione che trasforma il tempo in stringa in modo tale da poter essere visualizzato con l'oggetto UI text
    //vieni inserito + 1 perchè altrimenti partirebbe un secondo indietro
    private void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
