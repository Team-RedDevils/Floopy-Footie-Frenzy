using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject Ball;
    public GameObject SpawnPoint1;
    public GameObject SpawnPoint2;

  
    public void Spawn(string team)
    {
        Ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
        Ball.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

        if(team == "team1")
        {
            Ball.transform.position = SpawnPoint1.transform.position;
        }
        else
        {
            Ball.transform.position = SpawnPoint2.transform.position;
        }
        
    }
}
