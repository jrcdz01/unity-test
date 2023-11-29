using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CooldownTimer : Timer
{
    public bool CheckEndCooldown(){
        if( timeLeft <= 0 ){
            return true;
        }
        
        return false;
    }
}
