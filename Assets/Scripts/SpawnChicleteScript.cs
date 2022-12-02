using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnChicleteScript : MonoBehaviour
{
    public GameObject chiclete;
    public float spawnTimeC = 7;
   
    void Start()
    {
        if(transform.position.x>0){
            spawnTimeC = 11;
        }
        InvokeRepeating("AdicionaObstaculo", spawnTimeC, spawnTimeC);
    }

    
    void Update()
    {
        
    }

    Vector2 CriaPosicao() {
      Renderer renderer = GetComponent<Renderer>();
      var y1 = transform.position.y - renderer.bounds.size.y/2;
      var y2 = transform.position.y + renderer.bounds.size.y/2;
      var spawnPoint = new Vector2(transform.position.x, Random.Range(y1, y2));
      return spawnPoint;
   }

   void AdicionaObstaculo(){
      var spawnPoint = CriaPosicao();
      Adicionachiclete(spawnPoint);
   }

   void Adicionachiclete(Vector2 spawnPoint){
    //Verfica de qual lado esta o GameObject de spawn  
        //E chama a função do chiclete que define para qual lado ele vai ir, mudando a variavel speed
        if(transform.position.x>0){
            ChicleteScript script = chiclete.gameObject.GetComponent<ChicleteScript>();
            script.setLado(2);
        }
        Instantiate(chiclete, spawnPoint, Quaternion.identity);
   }
}
