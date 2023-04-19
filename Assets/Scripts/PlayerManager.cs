using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    public static PlayerManager Instance;
    PhotonView PV;
    GameObject player;

    private void Awake()
    {
        PV = GetComponent<PhotonView>();
        Instance = this;
    }

    void Start()
    {
        if (PV.IsMine)
        {
            CreatePlayer();
        }
    }

    void CreatePlayer()
    {
        Transform spawnpoint = SpawnManager.Instance.GetSpawnpoint();
        player = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "Ragdoll"), spawnpoint.position, Quaternion.identity, 0, new object[] {PV.ViewID});
    }

    public void Respawn()
    {
        PhotonNetwork.Destroy(player);
        CreatePlayer();
    }
}
