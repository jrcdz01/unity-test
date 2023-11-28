using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Timeline;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] GameObject pivotFrontCannon;
    [SerializeField] GameObject pivotRightCannon;
    [SerializeField] GameObject pivotLeftCannon;

    [Header("Projectile Stuff")]
    [SerializeField] protected GameObject projectile;
    [SerializeField] private string targetTag;
    [SerializeField] private int damagePower;
    private Vector2 cannonSelected;
    private Quaternion cannonRotation;

    void Update()
    {
        if(Input.GetButtonDown("Fire1")){
            cannonSelected = pivotFrontCannon.transform.position;
            cannonRotation = transform.rotation;
            StartCoroutine(CannonShoot(cannonSelected, cannonRotation));
        }

        if(Input.GetButtonDown("Fire2")){
            cannonSelected = pivotLeftCannon.transform.position;
            cannonRotation = transform.rotation*Quaternion.Euler(0,0,90).normalized;
            
            StartCoroutine(CannonShoot(cannonSelected, cannonRotation));
            StartCoroutine(CannonShoot(cannonSelected, cannonRotation*Quaternion.Euler(0,0,30).normalized));
            StartCoroutine(CannonShoot(cannonSelected, cannonRotation*Quaternion.Euler(0,0,-30).normalized));
        }

        if(Input.GetButtonDown("Fire3")){
            cannonSelected = pivotRightCannon.transform.position;
            cannonRotation = transform.rotation*Quaternion.Euler(0,0,-90).normalized;
            
            StartCoroutine(CannonShoot(cannonSelected, cannonRotation));
            StartCoroutine(CannonShoot(cannonSelected, cannonRotation*Quaternion.Euler(0,0,10).normalized));
            StartCoroutine(CannonShoot(cannonSelected, cannonRotation*Quaternion.Euler(0,0,-10).normalized));
        }
    }

    IEnumerator CannonShoot( Vector2 cannonPosition, Quaternion rotation ){
        Projectile fire = Instantiate(projectile, cannonPosition, rotation).GetComponent<Projectile>();
        
        Vector3 direction = ChooseProjectileDirection(pivotFrontCannon);
        
        fire.Setup(targetTag, damagePower);
        yield return null;
    }


    private Vector3 ChooseProjectileDirection(GameObject cannon){
        float posY = cannon.transform.position.y;
        float posX = cannon.transform.position.x;
        float temp = Mathf.Atan2(posY, posX) * Mathf.Rad2Deg;
        return new Vector3(0,0, temp);
    }
}