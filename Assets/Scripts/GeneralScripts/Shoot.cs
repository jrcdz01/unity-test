using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] protected GameObject projectile;
    [SerializeField] private string targetTag;
    [SerializeField] private int damagePower;
    [SerializeField] protected float cooldownTime;
    [SerializeField] protected CooldownTimer timer;

    public void SingleShoot(Vector2 cannonPosition, Quaternion cannonRotation){
        timer.StartTimer(cooldownTime);
        StartCoroutine(CannonShoot(cannonPosition, cannonRotation));
    }

    public void SideTripleShoot(Vector2 cannonPosition, Quaternion cannonRotation){
        timer.StartTimer(cooldownTime);
        StartCoroutine(CannonShoot(cannonPosition, cannonRotation));
        StartCoroutine(CannonShoot(cannonPosition, cannonRotation*Quaternion.Euler(0,0,30).normalized));
        StartCoroutine(CannonShoot(cannonPosition, cannonRotation*Quaternion.Euler(0,0,-30).normalized));
    }

    protected IEnumerator CannonShoot( Vector2 cannonPosition, Quaternion rotation){
        Projectile fire = Instantiate(projectile, cannonPosition, rotation).GetComponent<Projectile>();
        
        fire.Setup(targetTag, damagePower);
        yield return null;
    }
}
