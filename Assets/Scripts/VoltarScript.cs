using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VoltarScript : MonoBehaviour
{
    public void OnClickVoltar(){
         SceneManager.LoadScene("menu");
    }
}
