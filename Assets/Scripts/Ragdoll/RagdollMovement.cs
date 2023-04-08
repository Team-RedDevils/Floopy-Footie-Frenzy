using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollMovement : MonoBehaviour
{
    [SerializeField]
    private PlayerInput playerInput;
    [SerializeField]
    private Rigidbody hips;


    [SerializeField]
    private Transform cam;
    [SerializeField]
    private float turnSmoothTime = 0.1f;
    private float turnSmoothVel;


    [Header("Walking/Running")]
    [SerializeField]
    private float moveForce = 10;
    [SerializeField]
    private float currentSpeedLimit;
    [SerializeField]
    private float walkSpeedLimit = 5;
    [SerializeField]
    private float runSpeedLimit = 8;
    private float forceMultiplier = 100;
    private Vector3 movementVector;
    
    [SerializeField]
    private float jumpSpeed = 2.5f;
    private float ySpeed;
    float distToGround;



    // Start is called before the first frame update
    void Start()
    {

        Cursor.lockState = CursorLockMode.Locked;
        playerInput = GetComponent<PlayerInput>();

        distToGround = 0.6f;
    }

    // Update is called once per frame
    void Update()
    {
        currentSpeedLimit = playerInput.isRunning ? runSpeedLimit : walkSpeedLimit;

    }

    void FixedUpdate(){
        MovePlayer();
    } 
    

    void SetSpeedLimit(){
        currentSpeedLimit = playerInput.isRunning ? runSpeedLimit : walkSpeedLimit;
    }

    void MovePlayer(){


         if (playerInput.isJumping && IsGrounded())
        {
            
            ySpeed = jumpSpeed;
            
            hips.AddForce(Vector3.up * ySpeed * forceMultiplier * Time.deltaTime, ForceMode.Impulse);
        }
        
        if (!IsGrounded())
        {
            ySpeed += Physics.gravity.y * Time.deltaTime;
        }
        else
        {
            ySpeed = 0;
            playerInput.isJumping = false;
        }

        if(hips.velocity.magnitude < currentSpeedLimit){


            movementVector = playerInput._horizontal * -cam.right + playerInput._vertical * -cam.forward;


            /* movementVector = new Vector3(playerInput._horizontal,0f,playerInput._vertical).normalized; */
            if(movementVector.magnitude > 0){
                RotatePlayer();
                hips.AddForce(-movementVector*moveForce*forceMultiplier*Time.deltaTime,
                        ForceMode.VelocityChange);
            }
            else{

                hips.velocity = Vector3.zero;

            }

        }

    }

    void RotatePlayer(){
        float targetAngle = Mathf.Atan2(movementVector.x,movementVector.z)* Mathf.Rad2Deg ; 
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVel, turnSmoothTime);

        GetComponent<ConfigurableJoint>().targetRotation = Quaternion.Euler(0,- angle,0);

    }

    bool IsGrounded()
    {
        return Physics.Raycast(hips.transform.Find("BallTrigger").transform.position, Vector3.down, distToGround);
    }
}
