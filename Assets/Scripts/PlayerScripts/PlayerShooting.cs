using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEditor.Experimental.GraphView;
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
        if(Input.GetButtonDown("Fire1")  ){
            cannonSelected = pivotFrontCannon.transform.position;
            cannonRotation = transform.rotation;
            SingleShoot(cannonSelected, cannonRotation);
        }

        if(Input.GetButtonDown("Fire2")){
            cannonSelected = pivotLeftCannon.transform.position;
            cannonRotation = transform.rotation*Quaternion.Euler(0,0,90).normalized;
            SideTripleShoot(cannonSelected, cannonRotation);
        }

        if(Input.GetButtonDown("Fire3")){
            cannonSelected = pivotRightCannon.transform.position;
            cannonRotation = transform.rotation*Quaternion.Euler(0,0,-90).normalized;
            SideTripleShoot(cannonSelected, cannonRotation);
        }
    }  
}