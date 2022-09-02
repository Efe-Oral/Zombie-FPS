using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] Transform target;
    public float damage;

    private void Start()
    {

    }

    public void AttackHitEvent()
    {
        if(target == null) { return; }
        target.GetComponent<PlayerHealth>().TakeDamage(damage);
        print("BANG BANG");
    }
}
