using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SessionTimer : Timer
{
    [SerializeField] private FloatValue timerSelected;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private TMP_Text textScore;
    [SerializeField] private TMP_Text textLeftTimeUI;
    [SerializeField] private IntValue playerScore;
    // Start is called before the first frame update
    void Awake(){
        Time.timeScale = 1f;
    }
    void Start()
    {
        StartTimer(timerSelected.initialValue);
    }

    void Update(){
        if( timeLeft > 0 && startTimer){
            DecreaseTime();
            letfTimeUpdateUI();
        }else if( timeLeft <= 0){
           gameOver();
        }
    }

    private void gameOver(){
        Time.timeScale = 0f;
        textScore.text = playerScore.runtimeValue.ToString();
        gameOverPanel.SetActive(true);
    }

    private void letfTimeUpdateUI(){
        textLeftTimeUI.text = ((int)timeLeft).ToString();
    }
}
