using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI ScoreText;
    public int team1score = 0;
    public int team2score = 0;
    public void AddScore(string team)
    {
        if(team.Equals("team1"))
        {
            team1score++;
            Debug.Log("Team 1 scored!");
        }
        else{
            team2score++;
            Debug.Log("Team 2 scored!");
        }
    }
    public void UpdateScore()
    {
        ScoreText.text = "t1 " + team1score + "-" + team2score +" t2";
    }
    // Update is called once per frame
    void Update()
    {
        UpdateScore();
    }
}
