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

    void FixedUpdate(){
        UpdateAnimationHealth();
    }

    private void UpdateAnimationHealth(){
        float healthPercentage = currentHealth/initHealth;
        if( healthPercentage >= .5f && healthPercentage < 1){
            animator.SetBool("Half Health", true);
            animator.SetBool("Full Health", false);
        }else if( healthPercentage < .5f ){
            animator.SetBool("Half Health", false);
            animator.SetBool("Low Health", true);
        }
    }
}
