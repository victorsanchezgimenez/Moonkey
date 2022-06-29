using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    //Access to BuildSpawner script
    BuildSpawner buildSpawner;
    
    void Start()
    {
        //Initializing
        buildSpawner = GetComponent<BuildSpawner>();
    }
    
    public void SpawnTriggerEntered()
    {
        //Call MoveBuild function
        buildSpawner.MoveBuild();
    }
}
