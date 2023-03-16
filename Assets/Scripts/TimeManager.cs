using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    float startingTime = 180f;
    float currentTime = 0f;
    float timeAfterGoal = 1f;
    float centerTime = 3f;

    string onsetTeam;

    [SerializeField] TextMeshProUGUI TimeText;
    public SpawnManager spawnManager;

    void Start()
    {
        currentTime = startingTime;
    }

    void Update()
    {
        currentTime -= 1*Time.deltaTime;
        string minutes = Mathf.Floor(currentTime / 60).ToString("00");
        string seconds = Mathf.Floor(currentTime % 60).ToString("00");
        TimeText.text = minutes+":"+seconds;
    }
    public void goalHandler(string team)
    {
        onsetTeam = team;
        currentTime += timeAfterGoal;
        Invoke("Spawn", timeAfterGoal);
    }

    void Spawn()
    {
        spawnManager.Spawn(onsetTeam);
    }
}