using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollMovement : MonoBehaviour
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
    } 

    void MovePlayer(){


        movementVector = playerInput._horizontal * -hips.transform.right + 
                            playerInput._vertical * -hips.transform.forward;



        /* if(hips.velocity.magnitude < currentSpeedLimit){ */
        /*     hips.AddForce(movementVector.normalized*moveForce*forceMultiplier*Time.deltaTime); */
        /* } */
        /* if(movementVector == Vector3.zero){ */
        /*     hips.velocity = Vector3.zero; */
        /* } */

        if(hips.velocity.magnitude < currentSpeedLimit){
            if(Input.GetKey(KeyCode.W)){
                hips.AddForce(-hips.transform.forward*moveForce*forceMultiplier*Time.deltaTime);
            }
            if(Input.GetKey(KeyCode.S)){
                hips.AddForce(hips.transform.forward*moveForce*forceMultiplier*Time.deltaTime);
            }
            if(Input.GetKey(KeyCode.D)){
                hips.AddForce(-hips.transform.right*moveForce*forceMultiplier*Time.deltaTime);
            }
            if(Input.GetKey(KeyCode.A)){
                hips.AddForce(hips.transform.right*moveForce*forceMultiplier*Time.deltaTime);
            }
        }
    }
}
