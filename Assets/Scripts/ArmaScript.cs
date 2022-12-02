using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmaScript : MonoBehaviour
{
    public GameObject bala;
    public GameObject balaEspecial;
    public GameObject spawnBala;
    public Camera cam;
    private Vector3 posMouse;
    public PersonagemScript player;
    
    void Start()
    {
       cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
       player = gameObject.GetComponentInParent<PersonagemScript>();
    }

    void Update()
    {
        //Pega a posição do mouse na cena e passa para o vetor 
        posMouse = cam.ScreenToWorldPoint (Input.mousePosition);
        //Fixa a posição no eixo z para não movimentar nesse eixo 
        posMouse.z = transform.position.z; 
        //Modifica a posição da arma para a direção da posição do mouse
        transform.up = (posMouse-transform.position);
        Atirar();
    }

    void Atirar()
    {
        if (Input.GetMouseButtonDown(0)) {

            //Verifica se a variavel do personagem é igual a 1 e cria a bala de acordo 
            if(player.tiroEspecial==1){
                Instantiate(balaEspecial, spawnBala.transform.position, Quaternion.identity);
            }
            else
                Instantiate(bala, spawnBala.transform.position, Quaternion.identity);
        }
    }
}
