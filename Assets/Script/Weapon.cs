using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] float range;
    [SerializeField] float damage = 10f;
    [SerializeField] ParticleSystem shootVFX;

    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }
    private void Shoot()
    {
        PlayFireVFX();
        ProcessRayCast();
    }

    private void PlayFireVFX()
    {
        shootVFX.Play();
    }
    
    private void ProcessRayCast()
    {
        RaycastHit hit;
        if(Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range))
        {
            print(hit.transform.name + " has been hit.");
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if(target == null) // if we hit a thing with no tag ignore it.
            {
                return;
            }
            else if(target.CompareTag("Enemy"))
            {
                target.TakeDamage(damage);
            }
            //EnemyHealth.FindObjectOfType<EnemyHealth>().TakeDamage(damage);
        }
        else { return; }
    }
}
