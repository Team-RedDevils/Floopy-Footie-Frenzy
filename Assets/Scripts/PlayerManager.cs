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
    public int myTeam;

    private void Awake()
    {
        PV = GetComponent<PhotonView>();
        Instance = this;
    }

    void Start()
    {
        if (PV.IsMine)
        {  
            PV.RPC(nameof(GetTeam), RpcTarget.MasterClient);
            CreatePlayer();
        }
        Debug.Log(myTeam);
    }

    public void CreatePlayer()
    {
        Transform spawnpoint = RoomManager.Instance.GetSpawnpoint(myTeam);
        player = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "Ragdoll"), spawnpoint.position, Quaternion.identity, 0, new object[] {PV.ViewID});
    }

    public void Respawn()
    {
        PhotonNetwork.Destroy(player);
        CreatePlayer();
    }

    [PunRPC]
    void GetTeam()
    {
        myTeam = RoomManager.Instance.nextPlayerTeam;
        RoomManager.Instance.UpdateTeam();
        PV.RPC(nameof(SentTeam), RpcTarget.OthersBuffered, myTeam);
    }

    [PunRPC]
    void SentTeam(int team)
    {
        myTeam = team;
    }
}
