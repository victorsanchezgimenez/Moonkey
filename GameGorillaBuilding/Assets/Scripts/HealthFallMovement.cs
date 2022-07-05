using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthFallMovement : MonoBehaviour
{
    [Header("General Settings Fall Movement")]
    [Tooltip("General speedY")]
    [SerializeField] float speedY = 1f;
    [Tooltip("Smooth speedY")]
    [SerializeField][Range(0f, 1f)] float smoothY = 1f;
    [Header("GeneralSettings Rotation Object")]
    [Tooltip("General speedRot")]
    [SerializeField] float speedRot = 1f;
    [Tooltip("Smooth speedRot")]
    [SerializeField] [Range(0f, 1f)] float smoothRot = 1f;

    Rigidbody rb;

    void Start()
    {
        //Initialize Rigidbody
        rb = GetComponent<Rigidbody>();

    }
    
    void FixedUpdate()
    {
        MovementY();
        RotationObject();
    }

    private void RotationObject()
    {
        transform.Rotate(0f, speedRot * smoothRot * Time.deltaTime, 0f, Space.Self);
    }

    private void MovementY()
    {
        transform.position += new Vector3(0, -speedY * smoothY * Time.deltaTime, 0);
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

    void DestroyGameObject()
    {
        Destroy(this.gameObject);
    }
        
}
