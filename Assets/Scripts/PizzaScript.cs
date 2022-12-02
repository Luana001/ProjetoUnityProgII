using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaScript : AlimentoScript
{
    //Classe que herda os comportamentos do AlimentoScript 
    //Somente é definido os valores dos atributos deste alimento através do construtor do objeto
    PizzaScript(){
        forca = 2;
        ponto = 3;
    }

}

