using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI ScoreText;
    public int team1score = 0;
    public int team2score = 0;
    public string team1;
    public string team2;
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