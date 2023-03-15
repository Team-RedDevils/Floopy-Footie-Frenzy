using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed = 6f;
    public float turnRate = 600f;

    public Rigidbody rb;

    Vector3 movement;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        movement = new Vector3(horizontal, 0, vertical).normalized;
        
        //var targetAngle = Mathf.Atan2(horizontal, vertical) * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.Euler(0, targetAngle, 0);

        if(movement != Vector3.zero )
        {
            Quaternion rotation = Quaternion.LookRotation(movement, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, turnRate * Time.deltaTime);

            //transform.forward = movement;
        }
        
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }
}

