using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerHealthManager : HealthManager
{
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private TMP_Text textScore;
    [SerializeField] private IntValue playerScore;
    protected override void Death(){
        if( currentHealth <= 0 ){
            gameObject.SetActive(false);
            textScore.text = playerScore.runtimeValue.ToString();
            gameOverPanel.SetActive(true);
            Time.timeScale = 0f;

        }
    }
}
