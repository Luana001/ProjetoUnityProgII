using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickStartGame(){
         SceneManager.LoadScene("comecar");
    }
    
    public void OnClickPlacar(){
         SceneManager.LoadScene("placar");
    }
    
    public void OnClickCreditos(){
         SceneManager.LoadScene("creditos");
    }
    
    public void OnClickExitGame(){
         Application.Quit();
    }
}   

