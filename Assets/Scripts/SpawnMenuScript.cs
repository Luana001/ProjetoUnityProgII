using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMenuScript : MonoBehaviour
{
   public GameObject batata;
   public GameObject pizza;
   public GameObject lanche;
   public float spawnTime = 1;

   void Start() {
      InvokeRepeating("CriaPosicao", spawnTime, spawnTime);
   }
   
   void CriaPosicao() {
      Renderer renderer = GetComponent<Renderer>();
      var x1 = transform.position.x - renderer.bounds.size.x/2;
      var x2 = transform.position.x + renderer.bounds.size.x/2;
      var spawnPoint = new Vector2(Random.Range(x1, x2), transform.position.y);

      int vez = Random.Range(1,4);

      switch(vez){
         case 1: 
            Instantiate(batata, spawnPoint, Quaternion.identity);
            break;
         case 2:
            Instantiate(pizza, spawnPoint, Quaternion.identity);
            break;
         case 3: 
            Instantiate(lanche, spawnPoint, Quaternion.identity);
            break;
         
      }
   }
}