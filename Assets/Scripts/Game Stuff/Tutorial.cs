using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private BoolValue tutorialOff;
    [SerializeField] GameObject tutorialPanel;
    // Start is called before the first frame update
    void Awake()
    {
        if( tutorialOff.runtimeValue ){
            tutorialPanel.SetActive(false);
            Time.timeScale = 1f;
            return;
        }
        Time.timeScale = 0;
        tutorialPanel.SetActive(true);
    }

    public void TurnOffTutorial(){
         tutorialPanel.SetActive(false);
        tutorialOff.runtimeValue = true;
        Time.timeScale = 1f;
    }
}
