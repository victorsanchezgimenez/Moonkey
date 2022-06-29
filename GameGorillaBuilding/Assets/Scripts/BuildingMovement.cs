using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingMovement : MonoBehaviour
{
    [Header("General Settings")]
    [Tooltip("Speed of movement down")]
    [SerializeField] float speed = 1f;
    [SerializeField][Range(0f, 1f)] float smooth = 1f;


    void FixedUpdate()
    {
        DownMovement();
    }

    //Movement to -Y
    private void DownMovement()
    {
        this.transform.position -= new Vector3(0, speed * smooth + Time.deltaTime, 0);
    }
}
