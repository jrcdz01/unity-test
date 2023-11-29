using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Timeline;

public enum PlayerState{
    idle,
    stagger,
    rotating,
}

public class PlayerMovement : MonoBehaviour
{
    public PlayerState currentState;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotationSpeed;
    
    public Rigidbody2D playerRigidBody;
    
    private Quaternion rotationAngle;
    
    void Start(){
        currentState = PlayerState.idle;
        rotationAngle = transform.rotation;
    }

    // Update is called once per frame
    void Update(){
        if( Input.GetButton("Horizontal") && currentState != PlayerState.rotating ){
            Rotation();
        }
    }

    void FixedUpdate(){
        MoveForward();
    }

    void MoveForward(){
        Vector3 velocity = new(0, Input.GetAxisRaw("Vertical")*moveSpeed*Time.deltaTime, 0);
        
        // transform.position += rotationAngle*velocity;
        playerRigidBody.MovePosition( transform.position+(rotationAngle*velocity));
    }

    void Rotation(){
        Quaternion rotation = transform.rotation;

        float z = rotation.eulerAngles.z;

        z -=Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;

        transform.rotation = Quaternion.Euler(0, 0, z);
        rotationAngle = transform.rotation;
    }
}