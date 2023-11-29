using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : HealthManager
{
    [SerializeField] private IntValue playerPoints;
    protected override void Death(){
         if( currentHealth <= 0 ){
            Destroy(gameObject);
            playerPoints.runtimeValue+=1;
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
