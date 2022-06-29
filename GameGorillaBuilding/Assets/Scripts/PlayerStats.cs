using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [Header("General Stats Health Settings")]
    public int currentHealth = 3;
    public int minHealth = 1;
    public int maxHealth = 3;

    public void HitProcess()
    {
        if(currentHealth == minHealth)
        {
            Debug.Log("Muerto");
        }
        else
        {
            currentHealth--;
        }
    }

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
