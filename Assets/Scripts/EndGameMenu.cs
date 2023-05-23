using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class EndGameMenu : MonoBehaviour


{
   // public Score score;

    public void Start()
    {
    }
    public void GoMenu()
    {
        SceneManager.LoadScene(1);
    }
}