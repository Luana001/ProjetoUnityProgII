using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
   public GameObject batata;
   public GameObject pizza;
   public GameObject lanche; 
   public GameObject tomate;
   public GameObject brocolis;
   public GameObject morango;
   public GameObject escudo;
   public PersonagemScript player;
   public float spawnTimeE = 12.9f, spawnTimeB = 19.3f, spawnTimeT = 8.7f, spawnTimeM = 23.8f;

   void Start() {
      player = GameObject.FindGameObjectWithTag("PersonagemTag").GetComponent<PersonagemScript>();

      InvokeRepeating("AdicionaAlimento", 1, 0.5f);
      InvokeRepeating("AdicionaEscudo", spawnTimeE, spawnTimeE);
      
      InvokeRepeating("AdicionaTomate", spawnTimeT, spawnTimeT);
      
      InvokeRepeating("AdicionaBrocolis", spawnTimeB, spawnTimeB);
      
      InvokeRepeating("AdicionaMorango", spawnTimeM, spawnTimeM);
   }
   
   Vector2 CriaPosicao() {
      Renderer renderer = GetComponent<Renderer>();
      var x1 = transform.position.x - renderer.bounds.size.x/2;
      var x2 = transform.position.x + renderer.bounds.size.x/2;
      var spawnPoint = new Vector2(Random.Range(x1, x2), transform.position.y);
      return spawnPoint;
   }

   void AdicionaAlimento(){
      var spawnPoint = CriaPosicao();
      int vez = Random.Range(1,4);

         switch(vez){
            case 1: 
               AdicionaBatata(spawnPoint);
               break;
            case 2:
               AdicionaPizza(spawnPoint);
               break;
            case 3: 
               AdicionaLanche(spawnPoint);
               break;
         }
   }
   
   void AdicionaPizza(Vector2 spawnPoint){
      Instantiate(pizza, spawnPoint, Quaternion.identity);
   }

   void AdicionaBatata(Vector2 spawnPoint){
      Instantiate(batata, spawnPoint, Quaternion.identity);
   }

   void AdicionaLanche(Vector2 spawnPoint){
      Instantiate(lanche, spawnPoint, Quaternion.identity);
   }

   void AdicionaTomate(){
      if(player.vidasP<3 || player.vidasP>3 && player.vidasP<7){
      var spawnPoint = CriaPosicao();
      Instantiate(tomate, spawnPoint, Quaternion.identity);
      }
   }

   void AdicionaBrocolis(){
      if(player.vidasP>3){
      var spawnPoint = CriaPosicao();
      Instantiate(brocolis, spawnPoint, Quaternion.identity);
      }
   }

   void AdicionaMorango(){
      if(player.vidasP>3){
      var spawnPoint = CriaPosicao();
      Instantiate(morango, spawnPoint, Quaternion.identity);
      }
   }

   void AdicionaEscudo(){
      if(player.vidasP==3){
      var spawnPoint = CriaPosicao();
      Instantiate(escudo, spawnPoint, Quaternion.identity);
      }
   }
}
    
