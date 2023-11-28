using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [SerializeField] private int initHealth;
    private int currentHealth;
   

    public void Death(){
        if( currentHealth <= 0 ){
            Destroy(gameObject);
        }
    }

    public void GetHit( int damage ){
        Debug.Log("Dano recebido "+damage);
        currentHealth -= damage;
        Debug.Log("Vida restante "+currentHealth);
        if(currentHealth <= 0 ){
            Death();
        }
    }
}
