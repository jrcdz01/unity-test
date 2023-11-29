using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class EnemyMovemant : MonoBehaviour
{
    [SerializeField] private Rigidbody2D myRigidbody;
    [SerializeField] float moveSpeed;
    [SerializeField] string targetTag;
    private Transform target;
    
    void Awake(){
        if ( GameObject.FindGameObjectWithTag(targetTag) ){
            target = GameObject.FindGameObjectWithTag(targetTag).transform;
        }
    }

    void FixedUpdate() {
        if( target != null)
            MoveToTarget();
    }

    private void MoveToTarget(){
        Vector3 directionOfMovement = target.position - transform.position;
        directionOfMovement.Normalize();
        
        float z = Mathf.Atan2(directionOfMovement.y, directionOfMovement.x)*Mathf.Rad2Deg -90;
        transform.rotation = Quaternion.Euler(0, 0, z);
        
        directionOfMovement = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);

        myRigidbody.MovePosition(directionOfMovement);
    }

    public Transform GetTarget(){
        return target;
    }
}
