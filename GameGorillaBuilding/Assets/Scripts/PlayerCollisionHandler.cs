using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerStats))]
public class PlayerCollisionHandler : MonoBehaviour
{
    [Header("General Settings for Spawn Builds")]
    public SpawnManager spawnManager;

    [Header("Access to stats of Player")]
    PlayerStats stats;

    void Start()
    {
        stats = GetComponent<PlayerStats>();
    }
    private void OnTriggerEnter(Collider other)
    {
        switch(other.gameObject.tag)
        {
            //Taking damage
            case "Enemy":
                TriggerEnemy();
                break;
            
            case "Health":
                TriggerHealth();
                break;
            
            //Spawn the builds constantly
            case "SpawnManager":
                TriggerSpawnBuilds();
                break;
        }
    }


    private void TriggerEnemy()
    {
        stats.HitProcess();
    }

    private void TriggerHealth()
    {
        stats.HealthProcess();
    }

    private void TriggerSpawnBuilds()
    {
        spawnManager.SpawnTriggerEntered();
    }


}
