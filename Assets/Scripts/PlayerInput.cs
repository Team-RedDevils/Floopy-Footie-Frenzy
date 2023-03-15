using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [HideInInspector]
    public float _horizontal;
    [HideInInspector]
    public float _vertical;

    [HideInInspector]
    public float _mouseX;
    [HideInInspector]
    public float _mouseY;

    public event Action onDash = delegate {  };

    public bool isRunning;
    private KeyCode runKey;
    // Start is called before the first frame update
    void Start()
    {
        runKey = KeyCode.LeftShift;
    }

    // Update is called once per frame
    void Update()
    {
        GetMoveInput(); 
        CheckRunning();
        GetMouseInput();

    }
    void GetMoveInput(){
        _horizontal = Input.GetAxis("Horizontal");
        _vertical= Input.GetAxis("Vertical");
    }
    void CheckRunning(){
        if(Input.GetKeyDown(runKey)){
            isRunning = true;
        }
        if(Input.GetKeyUp(runKey)){
            isRunning  = false;
        }
    }

    void GetMouseInput(){
        _mouseX = Input.GetAxis("Mouse X");
        _mouseY = Input.GetAxis("Mouse Y");
    }
}
