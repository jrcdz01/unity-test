using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OptionsScript : MonoBehaviour
{
    [SerializeField]public FloatValue sessionTimer;
    [SerializeField]public FloatValue spawnTimer;
    
    public void SessionTimeSelect(int value){
        sessionTimer.initialValue = value switch
        {
            0 => 60,
            1 => 120,
            2 => 180,
            _ => (float)60,
        };
    }

    public void EnemySpawnTimeSelect(int value){
        spawnTimer.initialValue = value switch
        {
            0 => 5,
            1 => 10,
            2 => 15,
            _ => (float)5,
        };
    }
}
