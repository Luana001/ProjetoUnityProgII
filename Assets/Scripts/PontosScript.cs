using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PontosScript : MonoBehaviour
{
    public Text pontosUI;
    public Text recordeUI;
    public int pontos;

    void Start(){
        recordeUI.text = "Recorde: " + PlayerPrefs.GetInt("Recorde");
    }

    void Update()
    {
        if(pontos > PlayerPrefs.GetInt("Recorde")){
            PlayerPrefs.SetInt("Recorde", pontos);
        }
        pontosUI.text = "Pontuação: " + pontos;
    }
}
