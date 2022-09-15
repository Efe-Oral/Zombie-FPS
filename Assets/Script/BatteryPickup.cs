using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryPickup : MonoBehaviour
{
    [SerializeField] float restoreAngle;
    [SerializeField] float restoreIntensity;

    FlashLight batteryPickup;

    private void Start()
    {
        batteryPickup = FindObjectOfType<FlashLight>();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            batteryPickup.RestoreLightAngle(restoreAngle);
            batteryPickup.RestoreLightIntensity(restoreIntensity);
            Destroy(gameObject);
        }
    } 
}
