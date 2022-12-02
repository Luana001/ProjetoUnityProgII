using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public void OnClickStartGame(){
         SceneManager.LoadScene("comecar");
    }
    
    public void OnClickPlacar(){
         SceneManager.LoadScene("placar");
    }
    
    public void OnClickCreditos(){
         SceneManager.LoadScene("creditos");
    }

    public void OnClickTutorial(){
         SceneManager.LoadScene("tutorialAndar");
    }
    
    public void OnClickExitGame(){
         Application.Quit();
    }
}   

