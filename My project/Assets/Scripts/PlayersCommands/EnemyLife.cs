using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    [SerializeField]
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;

    public PlayerCount playerCount;


    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }
    void Update()
    {
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            if (playerCount.numberPlayers - 1 <= 0)
            {
                GameManager.instance.WinGame();
            }
        }
    }

    public void decreaseHealth(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

    public void incrementHealth(int health)
    {
        if (currentHealth < maxHealth && currentHealth > 0)
        {
            currentHealth += health - ((currentHealth + health) % maxHealth);
        }
    }


}
