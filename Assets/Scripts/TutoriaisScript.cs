using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutoriaisScript : MonoBehaviour
{
    void Update()
    {
        
    }
    public void OnClickStartGame(){
         SceneManager.LoadScene("comecar");
    }
    public void OnClickVoltar(){
         SceneManager.LoadScene("menu");
    }
    public void OnClickObstaculos(){
         SceneManager.LoadScene("tutorialObstaculos");
    }
    public void OnClickEscudo(){
         SceneManager.LoadScene("tutorialEscudo");
    }
    public void OnClickPontuação(){
         SceneManager.LoadScene("tutorialPontuação");
    }
    public void OnClickPowerUp(){
         SceneManager.LoadScene("tutorialPowerUp");
    }
}

