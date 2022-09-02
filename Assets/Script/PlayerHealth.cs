using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;
    
    public void TakeDamage(float damage)
    {
        hitPoints = hitPoints - damage;
          if( hitPoints <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("PLAYER IS DEAD");
    }
}
