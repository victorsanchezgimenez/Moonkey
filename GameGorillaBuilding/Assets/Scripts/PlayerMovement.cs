using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("General Settings")]
    [Tooltip("Movement speed of Gorilla")]
    [SerializeField] float speedX = 35;
    [SerializeField] float speedY = 7;

    [Header("Screen limitation Gorilla")]
    [SerializeField] float maxY;
    [SerializeField] float minY;

    [Header("Gorila and PlayerGuide Transforms")]
    [SerializeField] Transform gorilla;
    [SerializeField] Transform playerGuide;

    [Header("Joystick Stick")]
    public Joystick joystick;
    
    
    
    private float inputHorizontal;
    private float inputVertical;
    Rigidbody rb;

    void Start()
    {
        //Initialize RigidBody Gorilla
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        MovementAxis();
    }

    private void MovementAxis()
    {
        //Inputs joystick
        inputHorizontal = joystick.Horizontal * -speedX;
        inputVertical = joystick.Vertical * -speedY;

        //General move
        //Rotation Left-Right (correction on move)
        if(inputHorizontal != 0)
        {
            playerGuide.transform.Rotate(0f, -inputHorizontal * Time.deltaTime, 0f, Space.Self);
        }
        //Transform Up-Down
        if(inputVertical != 0)
        {
            //transform.Translate(0, inputVertical * Time.deltaTime, 0);
            //transform.localPosition = new Vector3(transform.localPosition.x, Mathf.Clamp(transform.localPosition.y, minY, maxY), transform.localPosition.z);
            transform.Translate(0, 0, inputVertical * Time.deltaTime);
            transform.localPosition = new Vector3(transform.localPosition.x, Mathf.Clamp(transform.localPosition.y, minY, maxY), transform.localPosition.z);
        }
    }
}
