
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnManager : MonoBehaviour
{


    public GameObject Ball;
    public GameObject Player;
    public Spawnpoint[] BallSpawnPoints;
    [SerializeField] Spawnpoint[] PlayerSpawnPoints;
    public Score score;
 

    public void Spawn(string team)
    {
        Ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
        Ball.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

        Ball.transform.position = (team == score.team1) ? BallSpawnPoints[1].transform.position
            : BallSpawnPoints[0].transform.position;


        Player.transform.position = PlayerSpawnPoints[Random.Range(0,PlayerSpawnPoints.Length)].transform.position;
    }

    /*
    public Transform GetSpawnpoint()
    {

        Debug.Log(PlayerSpawnPoints[3].transform.position);
        return PlayerSpawnPoints[Random.Range(0, PlayerSpawnPoints.Length)].transform;
    } */
}