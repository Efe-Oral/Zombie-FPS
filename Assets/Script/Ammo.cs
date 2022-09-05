using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] int ammoAmount = 8;

    public int GetCurrentAmmo()
    {
        return ammoAmount;
    }

    public void ReduceCurrentAmmo()
    {
        ammoAmount = ammoAmount - 1; 
        if(ammoAmount <= 0)
        {
            Debug.Log("RUN OUT OF AMMO!");
            ammoAmount = 0;
        }
    }
}
