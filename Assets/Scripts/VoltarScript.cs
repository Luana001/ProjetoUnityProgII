using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VoltarScript : MonoBehaviour
{
    void Update()
    {
        
    }

    public void OnClickVoltar(){
         SceneManager.LoadScene("menu");
    }
}
