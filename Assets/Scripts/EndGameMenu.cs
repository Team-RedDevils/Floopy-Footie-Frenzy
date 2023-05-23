using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class EndGameMenu : MonoBehaviour

   
{   public Score score;
    public TMP_Text team1score;
    public TMP_Text team2score;
    
    public void Start(){
        team1score.text = score.team1score.ToString();
        team2score.text = score.team1score.ToString();
    //	team1score.SetText(score.team1score.ToString());
    //	team2score.SetText(score.team2score.ToString());
    }
    public void GoMenu(){	
    	SceneManager.LoadScene("MenuScene");
    }
    public void ExitGame()
    {
        // Quit the application
        Application.Quit();
    }
}
