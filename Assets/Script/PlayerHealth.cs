using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;
    
    public void TakeDamage(float damage)
    {
        hitPoints = hitPoints - damage;
        isDead();
    }

    public bool isDead()
    {   
        if(hitPoints <= 0)
        {
            return true;
        } 
        return false;
    }
}
