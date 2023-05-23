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

    private void Awake()
    {
        PV = GetComponent<PhotonView>();
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


    public void UpdateScore()
    {
        ScoreText.text = team1 + " " + team1score + "-" + team2score + " " + team2;
    }


    void Update()
    {
        UpdateScore();
    }
}