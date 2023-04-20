using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollMovement : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private PlayerInput playerInput;
    [SerializeField]
    private Rigidbody hips;
    [SerializeField]
    private GameObject Root;


    private PhotonView PV;


    [Header("Rotating")]
    [SerializeField]
    private Transform cam;
    [SerializeField]
    private float turnSmoothTime = 0.5f;
    private float turnSmoothVel;


    [Header("Walking/Running")]
    [SerializeField]
    private float moveForce = 10;
    [SerializeField]
    private float walkSpeedLimit = 5;
    [SerializeField]
    private float runSpeedLimit = 8;
    [SerializeField]
    private float currentSpeedLimit;
    private float forceMultiplier = 100;
    private Vector3 movementVector;


    [Header("Jumping")]
    [SerializeField]
    private float jumpSpeed = 2.5f;
    [SerializeField]
    private float fallSpeed = 4f;
    [SerializeField]
    private ConfigurableJoint[] joints;
    private float distToGround;
    private bool canMove =true;


    private int stamina = 100;
    private bool healing = false;
    private bool decreasing = false;

    void Awake(){
        Cursor.lockState = CursorLockMode.Locked;
        playerInput = GetComponent<PlayerInput>();
        playerInput.onJump += Jump;
        PV = GetComponent<PhotonView>();
    }

    

    // Start is called before the first frame update
    void Start()
    {
        if (!PV.IsMine)
        {
            Destroy(PV.gameObject.transform.parent.Find("Root").gameObject);
        }
            distToGround = 0.6f;
     }


    // Update is called once per frame
    void Update()
    {
    if (!PV.IsMine)
        {
            return;
        }
         SetSpeedLimit();
        StaminaCheck();
    }


    void FixedUpdate(){
        if(canMove){
            MovePlayer();
        }
        IncreaseGravity();
    } 

    void StaminaCheck(){
        if(stamina < 100 && !healing ){
            StartCoroutine(nameof(IncreaseStamina));
        }
    }
    public int GetStamina(){
        return stamina;
    }

    IEnumerator IncreaseStamina(){
        healing = true;
        while(stamina < 100 && !decreasing){
            stamina++;
            yield return new WaitForSeconds(0.1f);
        }
        healing = false;

    }

    void SetSpeedLimit(){
        if(stamina > 0){
            if(playerInput.isRunning && !decreasing){
                print(decreasing);
                currentSpeedLimit = runSpeedLimit;
                StartCoroutine(nameof(DecreaseStamina));
            }
            else if(!playerInput.isRunning){
                currentSpeedLimit = walkSpeedLimit;
            }
        }
        else{
            currentSpeedLimit = walkSpeedLimit;
        }
    }

    void Jump(){
        if(IsGrounded() && canMove && stamina > 40){
            hips.AddForce((Vector3.up+(-transform.forward*1.2f))* jumpSpeed * forceMultiplier * Time.deltaTime, ForceMode.Impulse);
            stamina = stamina-40;
            StartCoroutine(nameof(ReleaseBody));
        }
    }

    IEnumerator ReleaseBody(){
        canMove = false;
        foreach(ConfigurableJoint j in joints){
            JointDrive jointDrive = j.angularXDrive;
            jointDrive.positionSpring = 100f;
            j.angularXDrive = jointDrive;
            j.angularYZDrive = jointDrive;
        }
        yield return new WaitForSeconds(2);

        foreach(ConfigurableJoint j in joints){
            JointDrive jointDrive = j.angularXDrive;
            jointDrive.positionSpring = 2000;
            j.angularXDrive = jointDrive;
            j.angularYZDrive = jointDrive;
        }
        canMove = true;
    }



    void IncreaseGravity(){
        if (!IsGrounded())
        {
            hips.AddForce(Vector3.down * fallSpeed * forceMultiplier * Time.deltaTime);
        }
    }

    void MovePlayer(){
        if(hips.velocity.magnitude < currentSpeedLimit){
            movementVector = playerInput._horizontal * -cam.right + playerInput._vertical * -cam.forward;

            if(movementVector.magnitude > 0){
                RotatePlayer();
                hips.AddForce(-movementVector * moveForce * forceMultiplier * Time.deltaTime,
                        ForceMode.VelocityChange);
            }

            else
            {
                hips.velocity = Vector3.zero;
            }
        }
    }
    IEnumerator DecreaseStamina(){
        decreasing = true;
        while(playerInput.isRunning && stamina > 0){
            stamina--;
            yield return new WaitForSeconds(0.05f);
        }
        decreasing = false;
    }

    void RotatePlayer()
    {
        float targetAngle = Mathf.Atan2(movementVector.x, movementVector.z) * Mathf.Rad2Deg;
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVel, turnSmoothTime);
        GetComponent<ConfigurableJoint>().targetRotation = Quaternion.Euler(0,- angle,0);

    }

    bool IsGrounded()
    {
        return Physics.Raycast(hips.transform.Find("BallTrigger").transform.position, Vector3.down, distToGround);
    }
}

