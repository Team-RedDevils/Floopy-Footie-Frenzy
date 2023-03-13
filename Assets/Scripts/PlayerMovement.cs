using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private PlayerInput playerInput;
    [SerializeField]
    private Rigidbody hips;


    [Header("Walking/Running")]
    [SerializeField]
    private float moveForce = 10;
    [SerializeField]
    private float currentSpeedLimit;
    [SerializeField]
    private float walkSpeedLimit = 5;
    [SerializeField]
    private float runSpeedLimit = 8;
    private float forceMultiplier = 1000;
    private Vector3 movementVector;

    // Start is called before the first frame update
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        currentSpeedLimit = playerInput.isRunning ? runSpeedLimit : walkSpeedLimit;
    }

    void FixedUpdate(){
        MovePlayer();
        /* TurnPlayer(); */
    } 

    void MovePlayer(){

        movementVector = new Vector3(playerInput._horizontal, 0, playerInput._vertical);
        movementVector = movementVector.normalized;

        if(hips.velocity.magnitude < currentSpeedLimit){
            hips.AddForce(movementVector*moveForce*forceMultiplier*Time.deltaTime);
        }
    }
    void TurnPlayer(){
        if(movementVector != Vector3.zero){
            Quaternion toRotation = Quaternion.LookRotation(movementVector, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation,
                    toRotation,120*Time.deltaTime);
        }

    }
}
