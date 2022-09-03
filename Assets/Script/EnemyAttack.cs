using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    PlayerHealth target;
    public float damage = 20;

    private void Awake()
    {
        target = FindObjectOfType<PlayerHealth>();
    }
    private void Start()
    {

    }

    public void AttackHitEvent()
    {
        if(target == null) { return; }
        target.TakeDamage(damage);
        print("BANG BANG");
    }
}
