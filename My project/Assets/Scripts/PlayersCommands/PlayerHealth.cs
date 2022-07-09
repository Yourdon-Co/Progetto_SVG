using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;
    public bool isAlive;

    // Start is called before the first frame update
    void Start()
    {
        isAlive = true;
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            isAlive = false;
            SceneManager.LoadScene("Home");

        }
        else
        {
            isAlive = true;
            //da spostare nello script Game Manager che gestirà la schermata di fine partita
        }
    }

    public void decreaseHealth(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);

    }
    public void setHealth(int health)
    {
        currentHealth = health;
    }
    public void incrementHealth(int health)
    {
        if (currentHealth < maxHealth && currentHealth > 0)
        {
            currentHealth += health - ((currentHealth+health)%maxHealth);
        }
    }
}
