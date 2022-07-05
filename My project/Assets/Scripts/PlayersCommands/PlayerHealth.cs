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
        if (currentHealth > 0)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                TakeDamage(20);
            }
            healthBar.SetHealth(currentHealth);
        }
        else
        {
            isAlive = false;
            SceneManager.LoadScene("Home");
            //da spostare nello script Game Manager che gestirà la schermata di fine partita
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        
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
