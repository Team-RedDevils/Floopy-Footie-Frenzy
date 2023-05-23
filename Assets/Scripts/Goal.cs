using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Goal : MonoBehaviour
{
    [SerializeField] GameObject LeftGoal;
    [SerializeField] GameObject RightGoal;
    [SerializeField] Score score;
    [SerializeField] TimeManager timeManager;




    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == LeftGoal)
        {
            score.AddScore(score.team2);
            timeManager.goalHandler(score.team2);
        }
        else if (other.gameObject == RightGoal)
        {
            score.AddScore(score.team1);
            timeManager.goalHandler(score.team1);
        }
    }
}