using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private float initialValue;
    private float runtimeValue;
    [SerializeField] private bool startTimer = false;
   
    void Start()
    {
       runtimeValue = initialValue; 
    }

    // Update is called once per frame
    void Update()
    {
        if( runtimeValue > 0 && startTimer)
            DecreaseTime();
    }

    public void DecreaseTime(){
        runtimeValue -= Time.deltaTime;
    }

    public void Setup( float amountTime ){
        initialValue = amountTime;
    }

    public void StartTimer(){
        startTimer = true;
    }
}
