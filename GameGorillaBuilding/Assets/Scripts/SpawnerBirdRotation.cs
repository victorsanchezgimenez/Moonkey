using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerBirdRotation : MonoBehaviour
{
    [Header("General Settings")]
    [SerializeField] float speed = 20f;
    [SerializeField][Range(0f, 1f)] float smooth = 1f;

    [Header("Getting transform of GameObject")]
    [SerializeField] Transform spawnerTransform;
    
    
    void Update() 
    {
        RotationMovement();    
    }

    //Constant rotation
    private void RotationMovement()
    {
        spawnerTransform.transform.Rotate(0f, speed * smooth * Time.deltaTime, 0f, Space.Self);
    }
}
