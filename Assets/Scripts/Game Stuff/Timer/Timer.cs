using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Timer : MonoBehaviour
{
    public float timeLeft;
    [SerializeField] protected bool startTimer = false;
   
    void FixedUpdate()
    {
        if( timeLeft > 0 && startTimer){
            DecreaseTime();
        }
    }

    public void DecreaseTime(){
        Debug.Log("Restam "+timeLeft+"s");
        timeLeft -= Time.deltaTime;
    }

    public void StartTimer(float time){
        timeLeft = time;
        startTimer = true;
    }

    public void Setup(float totalTime){
        timeLeft = totalTime;
    }
}