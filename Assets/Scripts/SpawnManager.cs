using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager Instance;

    public GameObject Ball;
    public Spawnpoint[] BallSpawnPoints;
    [SerializeField] Spawnpoint[] PlayerSpawnPoints;
    public Score score;


    private void Awake()
    {
        Instance = this;
    }

    public void Spawn(string team)
    {
        Ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
        Ball.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

        Ball.transform.position = (team == score.team1) ? BallSpawnPoints[1].transform.position
            : BallSpawnPoints[0].transform.position;

        PlayerManager.Instance.Respawn();
    }

    public Transform GetSpawnpoint()
    {
        return PlayerSpawnPoints[Random.Range(0, PlayerSpawnPoints.Length)].transform;
    }
}