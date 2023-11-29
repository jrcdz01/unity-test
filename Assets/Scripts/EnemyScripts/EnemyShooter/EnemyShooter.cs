using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class EnemyShooter : Enemy
{
    [SerializeField] private float attackRadius;
    private Transform target;
    
    void Start()
    {
        target = GetComponent<EnemyMovemant>().GetTarget();
    }

    void Update()
    {
        // Debug.Log(target);
        CheckDistanceToAttack();
    }

    private void CheckDistanceToAttack(){
         if( target == null)
            return;
        float distanceTarget =  Vector3.Distance(target.position, transform.position);
        // Debug.Log(distanceTarget);
        if (attackRadius <= distanceTarget ){
            if( GetComponent<EnemyShooting>() )
                GetComponent<EnemyShooting>().ShootAttack();
        }
    }
}
