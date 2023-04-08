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
    private GameObject hipsCopy;


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

    // Start is called before the first frame update
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();

    }

    // Update is called once per frame
    void Update()
    {
        SetSpeedLimit();
    }

    void FixedUpdate(){
        MovePlayer();
    } 
    

    void SetSpeedLimit(){
        currentSpeedLimit = playerInput.isRunning ? runSpeedLimit : walkSpeedLimit;
    }

    void MovePlayer(){


        if(hips.velocity.magnitude < currentSpeedLimit){

            movementVector = new Vector3(playerInput._horizontal,0f,playerInput._vertical).normalized;
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
        print(GetComponent<ConfigurableJoint>().targetRotation);
        float rotateAngle = Mathf.Atan2(movementVector.x,movementVector.z)* Mathf.Rad2Deg;
        GetComponent<ConfigurableJoint>().targetRotation = Quaternion.Euler(0,- rotateAngle,0);
    }
}
