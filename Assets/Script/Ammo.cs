using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] AmmoSlot[] ammoSlots;

    [System.Serializable]
    private class AmmoSlot
    {
        public AmmoType ammoType;
        public int ammoAmount;
    }

    public int GetCurrentAmmo(AmmoType ammoType)
    {
        return GetAmmoSlot(ammoType).ammoAmount;
    }

    public void ReduceCurrentAmmo(AmmoType ammoType)
    {
        GetAmmoSlot(ammoType).ammoAmount = GetAmmoSlot(ammoType).ammoAmount - 1;
        if(GetAmmoSlot(ammoType).ammoAmount <= 0)
        {
            //Debug.Log("RUN OUT OF AMMO!");
            GetAmmoSlot(ammoType).ammoAmount = 0;
        }
    }
    public void IncreaseAmmoAmount(AmmoType ammoType, int ammoIncrease)
    {
        GetAmmoSlot(ammoType).ammoAmount = GetAmmoSlot(ammoType).ammoAmount + ammoIncrease;
    }

    private AmmoSlot GetAmmoSlot(AmmoType ammoType)
    {
        foreach (AmmoSlot slot in ammoSlots)
        {
            if(slot.ammoType == ammoType)
            {
                return slot;
            }
        }
        return null;
    }
}
