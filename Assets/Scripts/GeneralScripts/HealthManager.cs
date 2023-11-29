using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
public class HealthManager : MonoBehaviour
{
    [SerializeField] protected int initHealth;
    [SerializeField] private TMP_Text textLife;
    [SerializeField] protected Animator animator;
    [SerializeField] protected int currentHealth;
   
   void Start(){
        currentHealth = initHealth;
        RestartAparence();
   }
    void Update(){
        textLife.text = currentHealth.ToString();
    }

    protected virtual void Death(){
        if( currentHealth <= 0 ){
            Destroy(gameObject);
        }
    }

    public void GetHit( int damage ){
        // Debug.Log("Dano recebido "+damage);
        currentHealth -= damage;
        // Debug.Log("Vida restante "+currentHealth);
        if(currentHealth <= 0 ){
            Death();
        }
    }

    private void RestartAparence(){
        animator.SetBool("Full Health", true);
        animator.SetBool("Half Health", false);
        animator.SetBool("Low Health", false);
    }
}
