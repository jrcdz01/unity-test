using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : Shoot
{
    [SerializeField] GameObject pivotCannon;

    public void ShootAttack(){       
        Vector2 cannonSelected = pivotCannon.transform.position;
        Quaternion cannonRotation = transform.rotation * Quaternion.Euler(0, 0, -180);
        
        SingleShoot(cannonSelected, cannonRotation);
    }
}