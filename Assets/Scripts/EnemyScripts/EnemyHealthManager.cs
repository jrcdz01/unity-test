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
}
