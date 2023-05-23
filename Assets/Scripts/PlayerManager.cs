using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
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
            PV.RPC(nameof(GetTeam), RpcTarget.All);
            CreatePlayer();
            //Torso, Stomach, Hips, Right Shoulder, Left Shoulder, Right Thigh, Left Thigh
        }
        Debug.Log(myTeam);
    }

    void CreatePlayer()
    {
        Transform spawnpoint = RoomManager.Instance.GetSpawnpoint(myTeam);
        player = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "Ragdoll"), spawnpoint.position, Quaternion.identity, 0, new object[] {PV.ViewID});
        if (myTeam == 2)
        {
            PV.RPC(nameof(setTeamColor), RpcTarget.All);
        }
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

    [PunRPC]
    void setTeamColor()
    {
        GameObject.Find("Torso").GetComponent<Renderer>().material.color = Color.blue;
        GameObject.Find("Stomach").GetComponent<Renderer>().material.color = Color.blue;
        GameObject.Find("Hips").GetComponent<Renderer>().material.color = Color.blue;
        GameObject.Find("Right Shoulder").GetComponent<Renderer>().material.color = Color.blue;
        GameObject.Find("Left Shoulder").GetComponent<Renderer>().material.color = Color.blue;
        GameObject.Find("Right Thigh").GetComponent<Renderer>().material.color = Color.blue;
        GameObject.Find("Left Thigh").GetComponent<Renderer>().material.color = Color.blue;
    }

    private void Update()
    {
        if (PV.IsMine) 
            Debug.Log(myTeam + ".takým");
    }
}
