using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Menu : MonoBehaviour
{

    [SerializeReference]
    GameObject SettingsUI;
    public void PlayGame()
    {
        SceneManager.LoadScene("Arena1");
    }

    public void OpenSettings()
    {
        SettingsUI.SetActive(true);
    }

    public void CloseSettings()
    {
        SettingsUI.SetActive(false);
    }
   public void OpenShop()
    {
         SceneManager.LoadScene("Shop");

    }
    public void OpenGarage()
    {
        SceneManager.LoadScene("Garage");
    }

    public void OpenHome()
    {
        SceneManager.LoadScene("Home");

    }
   
}