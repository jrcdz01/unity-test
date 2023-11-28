using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private int desaceleracion;
    public Rigidbody2D projectileRigidBody;
    protected string targetTag;
    [SerializeField] private Animator animator;
    [SerializeField] private float lifeTime;
    private int damagePower = 1;

    void Update(){
        DecreaseLifeTime();
        
        Vector3 pos = transform.position;
        Vector3 velocity = new(0, -speed * Time.deltaTime, 0);

        pos += transform.rotation * velocity;
        transform.position = pos;
    }

    public void Setup(string nameTag, int damagePowerSet){
        targetTag = nameTag;
        damagePower = damagePowerSet;
    }

    public void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.CompareTag(targetTag)){
            other.GetComponent<HealthManager>().GetHit(damagePower);
            StartCoroutine(clashCo());
        }
    }

    private void DecreaseLifeTime(){
        lifeTime-= 1f;
        if(lifeTime <= 0){
           StartCoroutine(clashCo());
        }
    }
    IEnumerator clashCo(){
        animator.SetBool("Collider", true);
        projectileRigidBody.velocity *= speed/desaceleracion;
        yield return null;
        yield return new WaitForSeconds(.30f);
        Destroy(this.gameObject);
    }
}
