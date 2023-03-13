using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    private float yOffset = 12;
    [SerializeField]
    private float zOffset = -10;

    [SerializeField]
    private Transform playerToFollow;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(playerToFollow.position.x, 
                playerToFollow.position.y + yOffset, playerToFollow.position.z + zOffset);
    }
}
