using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSpawnerBuilding : MonoBehaviour
{
    [Header("Getting SpawnManager")]
    [SerializeField] SpawnManager spawnManager;
    

    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.tag == "SpawnManager")
        {
            TriggerSpawnBuilds();
        }    
    }

    //Call function move builds
    private void TriggerSpawnBuilds()
    {
        spawnManager.SpawnTriggerEntered();
    }
}
