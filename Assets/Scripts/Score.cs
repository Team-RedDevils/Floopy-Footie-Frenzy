using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Photon.Pun;

public class Score : MonoBehaviourPunCallbacks
{

    public TextMeshProUGUI ScoreText;
    PhotonView PV;
    public int team1score = 0;
    public int team2score = 0;
    public string team1;
    public string team2;
    ExitGames.Client.Photon.Hashtable CustomeValue = new ExitGames.Client.Photon.Hashtable();

    private void Awake()
    {
        PV = GetComponent<PhotonView>();
    }

    private void Start()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            ScoreText.text = team1 + " " + team1score + "-" + team2score + " " + team2;
            CustomeValue.Add("Score", ScoreText.text);
            PhotonNetwork.CurrentRoom.SetCustomProperties(CustomeValue);
        }
        else
        {
            ScoreText.text = PhotonNetwork.CurrentRoom.CustomProperties["Score"].ToString();
            Debug.Log(ScoreText.text);
        }
    }

    [PunRPC]
    public void AddScore(string team)
    {
        if (team == team1)
        {
            team1score++;
            Debug.Log(team1 + " scored!");
        }
        else
        {
            team2score++;
            Debug.Log(team2 + " scored!");
        }
    }


    [PunRPC]
    public void UpdateScore()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            ScoreText.text = team1 + " " + team1score + "-" + team2score + " " + team2;
            if (CustomeValue.ContainsKey("Score"))
            {
                CustomeValue.Clear();
                CustomeValue.Add("Score", ScoreText.text);
            }
        }
        else
        {
            ScoreText.text = PhotonNetwork.CurrentRoom.CustomProperties["Score"].ToString();
        }
        
    }


    void Update()
    {
        UpdateScore();
    }
}