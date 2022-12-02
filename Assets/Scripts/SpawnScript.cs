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
   public float spawnTimeE = 10;

   void Start() {
      player = GameObject.FindGameObjectWithTag("PersonagemTag").GetComponent<PersonagemScript>();

      InvokeRepeating("AdicionaAlimento", 1, 0.5f);
      InvokeRepeating("AdicionaEscudo", spawnTimeE, spawnTimeE);
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

      if(player.vidasP > 1 && player.vidasP < 5){
         vez = Random.Range(1,7);
         
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
            case 4: 
               AdicionaTomate(spawnPoint);
               break;
            case 5:
               AdicionaBrocolis(spawnPoint);
               break;
            case 6:
               AdicionaMorango(spawnPoint);
               break;
         }

      } else {
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

   void AdicionaTomate(Vector2 spawnPoint){
      Instantiate(tomate, spawnPoint, Quaternion.identity);
   }

   void AdicionaBrocolis(Vector2 spawnPoint){
      Instantiate(brocolis, spawnPoint, Quaternion.identity);
   }

   void AdicionaMorango(Vector2 spawnPoint){
      Instantiate(morango, spawnPoint, Quaternion.identity);
   }

   
   void AdicionaEscudo(){
      if(player.vidasP==1){
      var spawnPoint = CriaPosicao();
      Instantiate(escudo, spawnPoint, Quaternion.identity);
      }
   }
}
    
