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
    [Header("Invencible Settings")]
    [SerializeField] GameObject player;
    PlayerCollisionHandler playerCollision;

    Rigidbody rb;

    void Start()
    {
        //Initialize Rigidbody
        rb = GetComponent<Rigidbody>();
        //Get script of playercollision for invencibility
        playerCollision = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCollisionHandler>();

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
                DestroyGameObject();
                break;
        }
    }

    //Destroy gameobject
    void DestroyGameObject()
    {
        Destroy(this.gameObject);
    }
    
}
