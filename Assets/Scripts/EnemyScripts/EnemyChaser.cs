using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyChaser : Enemy
{

    [SerializeField] int damagePower;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player")){
            //Player health decrease 1
            StartCoroutine(ExplosionCo());
            other.GetComponent<HealthManager>().GetHit(damagePower);
            Destroy(this.gameObject, deathEffectDelay);
        }
    }

    private IEnumerator ExplosionCo(){
        animator.SetBool("Collider", true);
        yield return null;
    }

}
