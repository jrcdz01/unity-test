using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject optionsPanel;
    public void Play(){
        SceneManager.LoadScene("MainScene");
    }

    public void Options(){
        optionsPanel.SetActive(true);
    }

    public void BackToMainMenu(){
        optionsPanel.SetActive(false);
    }

    public void QuitToDesktop(){
        Application.Quit();
    }
}
