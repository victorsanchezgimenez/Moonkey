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

    [Header("Getting AudioSource Music And Mute")]
    [SerializeField] AudioSource audioSourceMusic;

    [Header("AudioSource monkey")]
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip[] clip;
    [SerializeField][Range(0f, 1f)] float volumeScale = 0.5f;


    void Awake()
    {
        CheckAudioSourceMusic();
    }

    private void CheckAudioSourceMusic()
    {
        if (audioSourceMusic == null)
        {
            audioSourceMusic = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioSource>();
        }
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
                    PlayAudioMonkey(0);
                    TriggerEnemy();
                    StartCoroutine(Invencible());
                }
                break;
            
            //Health
            case "Health":
                PlayAudioMonkey(1);
                TriggerHealth();
                break;
            
            
            
        }
    }

    //Check if game is muted or not and if its not, play sound
    void PlayAudioMonkey(int sound)
    {
        if(!audioSourceMusic.mute)
            audioSource.PlayOneShot(clip[sound], volumeScale);

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
