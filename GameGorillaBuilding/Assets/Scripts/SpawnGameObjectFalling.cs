using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGameObjectFalling : MonoBehaviour
{

    [Header("GameObject Prefab")]
    [SerializeField] GameObject gameobjectFallingPrefab;
    [Header("General Probability Settings")]
    [SerializeField] int minProbRange = 0;
    [SerializeField] int maxProbRange = 15;
    [SerializeField] int actualProb = 5;
    [SerializeField] float respawnTime = 1.5f;

    [HideInInspector]
    public bool spawnActive = true;

    void Start()
    {
        StartCoroutine(FallingWave());
    }


    private void SpawnGameObject()
    {
        Instantiate(gameobjectFallingPrefab, transform.position, Quaternion.identity);
    }

    IEnumerator FallingWave()
    {
        //Loop
        while(spawnActive)
        {
            //Random number
            int n = Random.Range(minProbRange, maxProbRange);
            //Wait a seconds
            yield return new WaitForSeconds(respawnTime);
            //Random number == actualProb
            if (n == actualProb)
            {
                //Instantiate
                SpawnGameObject();
            }
        }
    }

    void OnDrawGizmosSelected() 
    {
        Gizmos.matrix = this.transform.localToWorldMatrix;
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawCube(Vector3.zero, Vector3.one);
    }
    
}
