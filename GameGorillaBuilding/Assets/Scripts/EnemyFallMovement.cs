using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFallMovement : MonoBehaviour
{
    [Header("General Settings")]
    [Tooltip("General speed")]
    [SerializeField] float speed = 1f;
    [Tooltip("Smooth speed")]
    [SerializeField][Range(0f, 1f)] float smooth = 1f;

    [Header("Getting AudioSource Music And Mute")]
    [SerializeField] AudioSource audioSourceMusic;

    [Header("AudioSource monkey")]
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip clip;
    [SerializeField][Range(0f, 1f)] float volumeScale = 0.5f;

    [Header("ParticleSystem GameObject Initialize")]
    [SerializeField] GameObject crashParticles;
    
    
    //Invencible settings
    PlayerCollisionHandler playerCollision;
    Rigidbody rb;
    
    void Awake()
    {
        CheckAudioSourceMusic();
    }

    void Start()
    {
        //Initialize Rigidbody
        rb = GetComponent<Rigidbody>();
        //Get script of playercollision for invencibility
        playerCollision = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCollisionHandler>();
        //GetBirdEnemy
        BirdEnemy();
        ScaffoldEnemy();
        //Get own audiosource
        audioSource = GetComponent<AudioSource>();
    }

    

    private void BirdEnemy()
    {
        if (this.gameObject.tag == "BirdEnemy")
        {
            this.transform.parent = GameObject.FindWithTag("SpawnerBird").transform;
        }
    }

    private void ScaffoldEnemy()
    {
        if (this.gameObject.tag == "ScaffoldEnemy")
        {
            Transform target = GameObject.FindWithTag("ScaffoldPointer").transform;
            transform.LookAt(new Vector3(target.position.x, transform.position.y, target.position.z));
        }
    }

    void FixedUpdate()
    {
        MovementY();
        
    }

    //Contiuous movement
    private void MovementY()
    {
        transform.position += new Vector3(0, -speed * smooth * Time.deltaTime, 0);
    }

   //Destroy elements that falls when arrive at end of screen or touch by player
    private void OnTriggerEnter(Collider other) 
    {
        switch(other.gameObject.tag)
        {
            case "DestroyEnemy":
                DestroyGameObject();
                break;
            case "Player":
                ActivateParticles();
                SoundCollision();
                DestroyGameObject();
                break;
        }
    }

   
    //Destroy gameobject
    void DestroyGameObject()
    {
        Destroy(this.gameObject);
    }


    private void CheckAudioSourceMusic()
    {
        if (audioSourceMusic == null)
        {
            audioSourceMusic = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioSource>();
        }
    }

    void SoundCollision()
    {
        if(!audioSourceMusic.mute)
        {
            audioSource.PlayOneShot(clip, volumeScale);
        }
    }

    private void ActivateParticles()
    {
        Debug.Log("Entering");
        Instantiate(crashParticles, transform.position, Quaternion.identity);
    }
    
}
