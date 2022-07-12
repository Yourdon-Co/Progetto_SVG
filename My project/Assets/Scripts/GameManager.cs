using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject VictoryEndGameUI;
    public GameObject DefeatEndGameUI;
    public float attesa=5f;

    public GameObject[] characterPrefabs;
    public GameObject enemyPrefab;
    public GameObject coinPrefab;
    public GameObject healthPrefab;
    public GameObject shieldPrefab;
    public GameObject powerPrefab;



    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
       //istanzio i vari elementi
       if(SceneManager.GetActiveScene().name== "Arena0")
        {

            LoadPlayer();
            LoadEnemy();
            LoadCoin();
        }
        else if (SceneManager.GetActiveScene().name == "Arena1")
        {
            LoadPlayer();
            LoadEnemy();
            LoadCoin();
            LoadPropShield();
        }
        else if (SceneManager.GetActiveScene().name == "Arena2")
        {
            LoadPlayer();
            LoadEnemy();
            LoadCoin();
            LoadPropShield();
            LoadPropDamage();
        }
        if (SceneManager.GetActiveScene().name == "Arena3")
        {
            LoadPlayer();
            LoadEnemy();
            LoadCoin();
            LoadPropDamage();
            LoadPropHealth();
            LoadPropShield();
        } 
    }

    public void LoseGame()
    {
        //attiva il panel sconfitta oppure quando termina il tempo 
        DefeatEndGameUI.SetActive(true);
        Invoke("CompleteGame", attesa);
    }

    
    public void WinGame()
    {
        //attiva il canva vittoria
        DefeatEndGameUI.SetActive(true);
        Invoke("CompleteGame", attesa);
    }
    public void CompleteGame()
    {
        //carica la schermata home
        SceneManager.LoadScene("Home");
    }

    public void LoadPlayer()
    {
        int selectedCharacter = PlayerPrefs.GetInt("selectedCharacter");
        GameObject playerPrefab = characterPrefabs[selectedCharacter];
        GameObject clone =Instantiate(playerPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        clone.name = "Player 1";

    }
    public void LoadEnemy()
    {
        Vector3 offset = new Vector3(10, 0, 10);
        GameObject clone = Instantiate(enemyPrefab, offset, Quaternion.identity);
        clone.name = "Enemey 1";

    }
    public void LoadCoin()
    {
        float planetRadius = 50;//raggio fel pianeta
        Vector3 position = Random.insideUnitSphere * planetRadius; 
        Instantiate(coinPrefab, position, Quaternion.identity);

    }
    public void LoadPropShield()
    {
        float planetRadius = 50;//raggio fel pianeta
        Vector3 position = Random.insideUnitSphere * planetRadius; 
        Instantiate(shieldPrefab, position, Quaternion.identity);
    }
    public void LoadPropHealth()
    {
        float planetRadius = 50;//raggio fel pianeta
        Vector3 position = Random.insideUnitSphere * planetRadius;
        Instantiate(healthPrefab, position, Quaternion.identity);
    }
    public void LoadPropDamage()
    {
        float planetRadius = 50;//raggio fel pianeta
        Vector3 position = Random.insideUnitSphere * planetRadius;
        Instantiate(powerPrefab, position, Quaternion.identity);
    }

}
