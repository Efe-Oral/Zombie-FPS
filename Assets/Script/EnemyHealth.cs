using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; 

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;
    Animator anim;

    public void TakeDamage(float damage)
    {
        BroadcastMessage("OnDamageTaken");
        hitPoints = hitPoints - damage;
        //print("Target has been hit " + hitPoints);
        if(hitPoints <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        anim = GetComponent<Animator>();
        anim.SetTrigger("die");
        gameObject.GetComponent<NavMeshAgent>().speed = 0;
        gameObject.GetComponent<NavMeshAgent>().angularSpeed = 0;
        GetComponent<EnemyAI>().turnSpeed = 0f;
        //GetComponent<EnemyAI>().enabled = false; Same thing but disables completely
        Destroy(GetComponent<CapsuleCollider>());
        //Destroy(gameObject); //Enemy killed
    }
}
