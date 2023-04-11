using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public void PlayGame() {  
        SceneManager.LoadScene("Ozan");  
        
    }  

   public void QuitGame() {
        Application.Quit();
   }
}
