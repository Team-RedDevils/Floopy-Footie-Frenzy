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

        if(hips.velocity.magnitude < currentSpeedLimit){
            //else statements are to prevent drifting when off button
            if(Input.GetKey(KeyCode.W)){
                hips.AddForce(-hips.transform.forward*moveForce*forceMultiplier*Time.deltaTime);
            }
            else{
                if(transform.InverseTransformDirection(hips.velocity).z < 0){
                    hips.velocity = new Vector3(hips.velocity.x,hips.velocity.y,0);
                }
            }
            if(Input.GetKey(KeyCode.S)){
                hips.AddForce(hips.transform.forward*moveForce*forceMultiplier*Time.deltaTime);
            }
            else{
                if(transform.InverseTransformDirection(hips.velocity).z > 0){
                    hips.velocity = new Vector3(hips.velocity.x,hips.velocity.y,0);
                }
            }
            if(Input.GetKey(KeyCode.D)){
                hips.AddForce(-hips.transform.right*moveForce*forceMultiplier*Time.deltaTime);
            }
            else{
                if(transform.InverseTransformDirection(hips.velocity).x < 0){
                    hips.velocity = new Vector3(0,hips.velocity.y,hips.velocity.z);
                }
            }
            if(Input.GetKey(KeyCode.A)){
                hips.AddForce(hips.transform.right*moveForce*forceMultiplier*Time.deltaTime);
            }
            else{
                if(transform.InverseTransformDirection(hips.velocity).x < 0){
                    hips.velocity = new Vector3(0,hips.velocity.y,hips.velocity.z);
                }
            }
        }
    }
}
