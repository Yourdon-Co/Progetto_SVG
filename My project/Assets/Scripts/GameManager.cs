using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField]
    private GameObject[] players;

    bool isEnd = false;
    float attesa = 10.0f;

    public GameObject endGameUI;

    void Start()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
    }
    public void EndGame()
    {
        if (!isEnd)
        {
            isEnd = true;
            Invoke("CompleteGame", attesa);
        }

    }
    public void CompleteGame()
    {
        endGameUI.SetActive(true);
    }
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);    
        }
    }
}
