using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    private float rotationSpeed = 1;
    [SerializeField ]
    private PlayerInput playerInput;
    [SerializeField ]
    private Transform cameraHolder;
    [SerializeField ]
    private float stomachOffset = 10;

    private float mouseXRotation;
    private float mouseYRotation;


    [SerializeField]
    private float mouseYClamp = -15;
    [SerializeField]
    private float mouseZClamp = 15;

    [SerializeField ]
    private ConfigurableJoint hipJoint, stomachJoint;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate(){
        CamControl();
    }

    void CamControl(){
        mouseXRotation += playerInput._mouseX * rotationSpeed ;
        mouseYRotation -= playerInput._mouseY * rotationSpeed ;
        mouseYRotation = Mathf.Clamp(mouseYRotation, mouseYClamp,mouseZClamp);

        Quaternion holderRotation = Quaternion.Euler(-mouseYRotation, mouseXRotation,0);
        cameraHolder.rotation = holderRotation;

        hipJoint.targetRotation = Quaternion.Euler(0,- mouseXRotation,0);
        stomachJoint.targetRotation = Quaternion.Euler(+mouseYRotation + stomachOffset,0,0);
    }
}
