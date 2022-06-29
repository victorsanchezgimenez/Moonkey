using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("General Settings")]
    [Tooltip("Movement speed of Gorilla")]
    [SerializeField] float speedX = 50f;
    [SerializeField] float speedY = 10f;

    [Header("Gorila and PlayerGuide Transforms")]
    [SerializeField] Transform gorilla;
    [SerializeField] Transform playerGuide;
    
    
    private float inputHorizontal;
    private float inputVertical;
    Rigidbody rb;

    void Start()
    {
        //Taking RigidBody Gorilla
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        MovementAxis();
    }

    private void MovementAxis()
    {
        //Inputs
        inputHorizontal = Input.GetAxis("Horizontal");
        inputVertical = Input.GetAxis("Vertical");

        //General move
        //Rotation Left-Right
        playerGuide.transform.Rotate(0f, inputHorizontal * Time.deltaTime * speedX, 0f, Space.Self);
        //Transform Up-Down
        transform.localPosition += new Vector3(0, inputVertical, 0) * Time.deltaTime * speedY;
    }
}
