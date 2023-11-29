using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState{
    idle,
    stagger,
    rotating,
}

public class Enemy : MonoBehaviour
{
    [SerializeField] protected int enemyHealth;
    [SerializeField] protected Animator animator;
    [SerializeField] protected float deathEffectDelay;
    // Start is called before the first frame update
}
