using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;
    [SerializeField] Canvas _canvas;
    [SerializeField] TextMeshProUGUI HP;

    void Start()
    { 
        _canvas.enabled = false;
    }

    public void TakeDamage(float damage)
    {
        hitPoints = hitPoints - damage;
        HP.text = ("Health: ") + hitPoints.ToString();
        StartCoroutine(ShowDamage());
        isDead();
    }

    public void isDead()
    {   
        if(hitPoints <= 0)
        {
            GetComponent<DeathHandler>().HandleDeath();
        } 
    }
    IEnumerator ShowDamage()
    {
        _canvas.enabled = true;
        yield return new WaitForSeconds(0.5f);
        _canvas.enabled = false;
    }
}
