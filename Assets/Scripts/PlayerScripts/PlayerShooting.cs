using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class PlayerShooting : Shoot
{
    [SerializeField] GameObject pivotFrontCannon;
    [SerializeField] GameObject pivotRightCannon;
    [SerializeField] GameObject pivotLeftCannon;

    [Header("Projectile Stuff")]
   
    private Vector2 cannonSelected;
    private Quaternion cannonRotation;

    void Update()
    {
        if(Input.GetButtonDown("Fire1")  && timer.CheckEndCooldown()){
            cannonSelected = pivotFrontCannon.transform.position;
            cannonRotation = transform.rotation;
            SingleShoot(cannonSelected, cannonRotation);
        }

        if(Input.GetButtonDown("Fire2") && timer.CheckEndCooldown()){
            cannonSelected = pivotLeftCannon.transform.position;
            cannonRotation = transform.rotation*Quaternion.Euler(0,0,90).normalized;
            SideTripleShoot(cannonSelected, cannonRotation);
        }

        if(Input.GetButtonDown("Fire3") && timer.CheckEndCooldown()){
            cannonSelected = pivotRightCannon.transform.position;
            cannonRotation = transform.rotation*Quaternion.Euler(0,0,-90).normalized;
            SideTripleShoot(cannonSelected, cannonRotation);
        }
    }  
}