using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Photon.Pun;


public class TimeManager : MonoBehaviourPunCallbacks
{
    public float startingTime;
    float currentTime = 0f;
    float timeAfterGoal = 1f;
    //float centerTime = 3f;

    string onsetTeam;

    [SerializeField] TextMeshProUGUI TimeText;
    public SpawnManager spawnManager;
    
    void Start()
    {
        currentTime = startingTime;
    }

    [PunRPC]
    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        string minutes = Mathf.Floor(currentTime / 60).ToString("00");
        string seconds = Mathf.Floor(currentTime % 60).ToString("00");
        TimeText.text = minutes + ":" + seconds;

        if (currentTime <= 0)
        {
            TimeText.text = "00:00";
        }
    }
    public void goalHandler(string team)
    {
        onsetTeam = team;
        currentTime += timeAfterGoal;
        Invoke(nameof(Spawn), timeAfterGoal);
    }

    void Spawn()
    {
        spawnManager.Spawn(onsetTeam);
    }
}
