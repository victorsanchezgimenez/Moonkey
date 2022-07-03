using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [Header("General Stats Health Settings")]
    public int currentHealth = 3;
    public int minHealth = 0;
    public int maxHealth = 3;
    [Header("Getting GameObject Game Over Menu")]
    [SerializeField] GameObject gameOverMenu;

    void Start() 
    {
        //Disable gameOverMenu at start of game
        gameOverMenu.SetActive(false);    
    }
    //Damage
    public void HitProcess()
    {
        currentHealth--;

        if(currentHealth <= minHealth)
        {
            Time.timeScale = 0f;
            gameOverMenu.SetActive(true);
        }
        
    }

    //Health
    public void HealthProcess()
    {
        if(currentHealth == maxHealth)
        {
            Debug.Log("Vida maxima");
        }
        else
        {
            currentHealth++;
        }
    }
}
