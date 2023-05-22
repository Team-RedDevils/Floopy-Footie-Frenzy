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
    private bool scoreUpdated = false;
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
            CustomeValue.Add("Team1Score", team1score);
            CustomeValue.Add("Team2Score", team2score);
            PhotonNetwork.CurrentRoom.SetCustomProperties(CustomeValue);
        }
        else
        {
            team1score = int.Parse(PhotonNetwork.CurrentRoom.CustomProperties["Team1Score"].ToString());
            team2score = int.Parse(PhotonNetwork.CurrentRoom.CustomProperties["Team2Score"].ToString());
            ScoreText.text = team1 + " " + team1score + "-" + team2score + " " + team2;
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
        scoreUpdated = true;
    }


    [PunRPC]
    public void UpdateScore()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            ScoreText.text = team1 + " " + team1score + "-" + team2score + " " + team2;
            CustomeValue.Clear();
            CustomeValue.Add("Team1Score", team1score);
            CustomeValue.Add("Team2Score", team2score);
            PhotonNetwork.CurrentRoom.SetCustomProperties(CustomeValue);
        }
        else
        {
            team1score = int.Parse(PhotonNetwork.CurrentRoom.CustomProperties["Team1Score"].ToString());
            team2score = int.Parse(PhotonNetwork.CurrentRoom.CustomProperties["Team2Score"].ToString());
            ScoreText.text = team1 + " " + team1score + "-" + team2score + " " + team2;
            Debug.Log(ScoreText.text);
        }
        scoreUpdated = false;
    }


    void Update()
    {
        if(scoreUpdated)
        {
            UpdateScore();
        }
    }
}