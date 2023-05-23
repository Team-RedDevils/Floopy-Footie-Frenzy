using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameMenu : MonoBehaviour

   
{   
   
    public void GoMenu(){	
    	SceneManager.LoadScene(1);
    }
    public void ExitGame()
    {
        // Quit the application
        Application.Quit();
    }
}
