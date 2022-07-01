using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBananaController : MonoBehaviour
{
    [Header("Health Bar Settings")]
    [SerializeField] PlayerStats health;
    public Image[] bananas;
    public Sprite fullBanana;
    public Sprite emptyBanana;


    //Fill or empty bananas depends of current health
    void Update()
    {
        for(int i = 0; i < bananas.Length; i++)
        {
            if(i < health.currentHealth)
            {
                bananas[i].sprite = fullBanana;
            }
            else
            {
                bananas[i].sprite = emptyBanana;
            }
        }
    }
}
