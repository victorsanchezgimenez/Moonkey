using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerStats))]
public class PlayerCollisionHandler : MonoBehaviour
{
    [Header("Access to stats of Player")]
    [SerializeField] PlayerStats stats;

    [Header("Invencible Settings")]
    [SerializeField] SkinnedMeshRenderer meshRenderer;
    [SerializeField] CapsuleCollider playerCollider;
    [SerializeField] float timeInvencible = 0.2f;
    public bool isInvencible = false;

    void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        switch(other.gameObject.tag)
        {
            //Taking damage and inmortality
            case "Enemy":
            case "ScaffoldEnemy":
            case "BirdEnemy":
                if(!isInvencible)
                {
                    TriggerEnemy();
                    StartCoroutine(Invencible());
                }
                break;
            
            //Health
            case "Health":
                TriggerHealth();
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

    //Invencible function
    private IEnumerator Invencible()
    {
        isInvencible = true;
        meshRenderer.enabled = false;
        playerCollider.enabled = false;
        yield return new WaitForSeconds(timeInvencible);
        meshRenderer.enabled = true;
        yield return new WaitForSeconds(timeInvencible);
        meshRenderer.enabled = false;
        yield return new WaitForSeconds(timeInvencible);
        meshRenderer.enabled = true;
        yield return new WaitForSeconds(timeInvencible);
        meshRenderer.enabled = false;
        yield return new WaitForSeconds(timeInvencible);
        meshRenderer.enabled = true;
        yield return new WaitForSeconds(timeInvencible);
        meshRenderer.enabled = false;
        yield return new WaitForSeconds(timeInvencible);
        playerCollider.enabled = true;
        meshRenderer.enabled = true;
        isInvencible = false;
    }


}
