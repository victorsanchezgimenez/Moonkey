using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [Header("General Stats Health Settings")]
    public int currentHealth = 3;
    public int minHealth = 0;
    public int maxHealth = 3;


    //Damage
    public void HitProcess()
    {
        currentHealth--;

        if(currentHealth <= minHealth)
        {
            Debug.Log("Muerto");
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
