using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject Ball;
    public GameObject[] BallSpawnPoints;
    public GameObject[] PlayerSpawnPoints;
    public Score score;

  
    public void Spawn(string team)
    {
        Ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
        Ball.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

        Ball.transform.position = (team == score.team1) ? BallSpawnPoints[1].transform.position 
            : BallSpawnPoints[0].transform.position;
      /*
        if (team == score.team1)
        {
            Ball.transform.position = BallSpawnPoints[1].transform.position;
        }
        else
        {
            Ball.transform.position = BallSpawnPoints[0].transform.position;
        }
        */
    }
}
