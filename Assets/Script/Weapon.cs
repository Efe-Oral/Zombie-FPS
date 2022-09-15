using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] float range;
    [SerializeField] float damage = 10f;
    [SerializeField] ParticleSystem shootVFX;
    [SerializeField] GameObject hitEffect;
    [SerializeField] Ammo ammoSlot;
    [SerializeField] AmmoType ammoType;
    [SerializeField] float timeBetweenShots = 0.5f;
    [SerializeField] TextMeshProUGUI ammoText;

    bool canShoot = true;

    void OnEnable()
    {
        canShoot = true;
        //ammoText.text = ammoSlot.GetCurrentAmmo(ammoType).ToString();
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0) && ammoSlot.GetCurrentAmmo(ammoType)> 0 && canShoot)
        {
            StartCoroutine(Shoot());
            ammoSlot.ReduceCurrentAmmo(ammoType);
        }
        DisplayAmmo();
    }

    IEnumerator Shoot()
    {
        canShoot = false;
        PlayFireVFX();
        ProcessRayCast();
        yield return new WaitForSeconds(timeBetweenShots);
        canShoot = true;
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
            CreateHitImpact(hit);
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
    private void CreateHitImpact(RaycastHit hit)
    {
        GameObject impact = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impact, 0.1f);
    }
    private void DisplayAmmo()
    {
        ammoText.text = ammoSlot.GetCurrentAmmo(ammoType).ToString();
    }
}
