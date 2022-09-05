using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathHandler : MonoBehaviour
{
    [SerializeField] Canvas gameOverCanvas;
    PlayerHealth playerHealth;

    void Start()
    {
        //Locking the cursor after dying and restarting the game
        Cursor.lockState = CursorLockMode.Locked;
        playerHealth = GetComponent<PlayerHealth>();
        gameOverCanvas.enabled = false;
    }

    void Update()
    {
        if(playerHealth.isDead())
        {
            HandleDeath();
        }
    }

    public void HandleDeath()
    {
        gameOverCanvas.enabled = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
