using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Goal : MonoBehaviour
{
    public GameObject LeftGoal;
    public GameObject RightGoal;
    public Score score;
    public TimeManager timeManager;
    


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == LeftGoal)
        {
            score.AddScore("team2");
            timeManager.goalHandler("team1");
        }
        else if (other.gameObject == RightGoal)
        {
            score.AddScore("team1");
            timeManager.goalHandler("team2");
        }
    }
}
