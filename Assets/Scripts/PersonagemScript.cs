using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PersonagemScript : MonoBehaviour

{
    public float speed = 5;
    public int vidasP = 5;
    public GameObject escudo;

    void Start()
    {
        EscudoScript script =  escudo.gameObject.GetComponent<EscudoScript>();
        script.vidas = 4;
        Instantiate(escudo, transform.position, Quaternion.identity, transform);
    }

    void Update()
    {
        MovimentaHorizontal();
        MovimentaVertical();
        LimitarEmX();
        LimitarEmY();
    }

    void MovimentaHorizontal(){
        //move a nave na horizontal com as setas ou com as teclas A e D
        //Eixo X - na horizontal
        float horizontal = Input.GetAxis("Horizontal") * speed * Time.deltaTime;

        transform.Translate(horizontal, 0, 0); //Aplicando as mudanças
    }
    
    void MovimentaVertical(){
        //move a nave na vertical com as setas ou com as teclas w e s
        //Eixo X - na vertical
        float vertical = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        transform.Translate(0, vertical, 0); //Aplicando as mudanças
    }

    void LimitarEmX()
   {
     //Restringir o movimento entre dois valores
     if(transform.position.x <= -7.16f || transform.position.x >= 7.2f){
          // Criando o limite
          float xPos = Mathf.Clamp (transform.position.x,-7.16f,7.2f);
          // Limitando
          transform.position = new Vector3(xPos,transform.position.y, transform.position.z);
     }
   }

    void LimitarEmY()
   {
     //Restringir o movimento entre dois valores
     if(transform.position.y <= -4.16f || transform.position.y >= 4.2f){
          // Criando o limite
          float yPos = Mathf.Clamp (transform.position.y,-4.16f,4.2f);
          // Limitando
          transform.position = new Vector3(transform.position.x,yPos, transform.position.z);
     }
   }

    IEnumerator esperarTempo(float tempo){
        yield return new WaitForSeconds(tempo);
        speed = 5;
    }

   void OnTriggerEnter2D (Collider2D outro){
      if(outro.gameObject.tag == "batataTag" || outro.gameObject.tag == "pizzaTag" || outro.gameObject.tag == "lancheTag"){
         vidasP = vidasP - 1; 
         Destroy(outro.gameObject);
         if(vidasP==0){
             Destroy(this.gameObject);
             SceneManager.LoadScene("menu");
         }
      }
      
      if(outro.gameObject.tag == "escudinhoTag"){
         vidasP = 2;
         Destroy(outro.gameObject);
         Instantiate(escudo, gameObject.transform.position, Quaternion.identity, gameObject.transform);
      }

    if(outro.gameObject.tag == "ChicleteTag"){
         Destroy(outro.gameObject);
         speed = 1.6f;
         StartCoroutine(esperarTempo(10f));
         
      }
   }
}
