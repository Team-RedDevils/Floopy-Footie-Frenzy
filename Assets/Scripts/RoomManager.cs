using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;
using System.IO;

public class RoomManager : MonoBehaviourPunCallbacks
{
    public static RoomManager Instance;
    public GameObject Ball;
    public Spawnpoint[] BallSpawnPoints;
    [SerializeField] Spawnpoint[] RedTeamPlayerSpawnPoints;
    [SerializeField] Spawnpoint[] BlueTeamPlayerSpawnPoints;
    public Score score;
    public int nextPlayerTeam;
    private void Awake()
    {
        //Only one room manager exists
        if (Instance)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        Instance = this;
    }
    public void Spawn(string team)
    {
        Ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
        Ball.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

        Ball.transform.position = (team == score.team1) ? BallSpawnPoints[1].transform.position
            : BallSpawnPoints[0].transform.position;

        //PlayerManager.Instance.Respawn();
    }

    public Transform GetSpawnpoint(int playerTeam)
    {
        if (playerTeam == 1)
        {
            return RedTeamPlayerSpawnPoints[Random.Range(0, RedTeamPlayerSpawnPoints.Length)].transform;
        }
        else
        {
            return BlueTeamPlayerSpawnPoints[Random.Range(0, BlueTeamPlayerSpawnPoints.Length)].transform;
        }
    }

    public void UpdateTeam()
    {
        if (nextPlayerTeam == 1)
        {
            nextPlayerTeam = 2;
        }
        else
        {
            nextPlayerTeam = 1;
        }
    }

    public override void OnEnable()
    {
        base.OnEnable();
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public override void OnDisable()
    {
        base.OnDisable();
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    public void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
    {
        if (scene.buildIndex == 2)
        {
            PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PlayerManager"), GetSpawnpoint(nextPlayerTeam).position, GetSpawnpoint(nextPlayerTeam).rotation);
        }
    }

}