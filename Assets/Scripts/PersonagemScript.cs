using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PersonagemScript : MonoBehaviour

{
    public float speed = 5;
    public int vidasP = 7;
    public GameObject escudo;
    public int afetado = 0;
    public int invencivel = 0;
    public int tiroEspecial = 0;
    public Sprite normal;
    public Sprite gordinho;
    public Sprite obeso;
    public AudioClip comer;
    public AudioClip dano;
    
    
    void Start()
    {
        Instantiate(escudo, transform.position, Quaternion.identity, transform);
    }

    void Update()
    {
        MovimentaHorizontal();
        MovimentaVertical();
        LimitarEmX();
        LimitarEmY();
        atualizaPlayer();
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

    IEnumerator desafetar(float tempo){
        yield return new WaitForSeconds(tempo);
        afetado=0;
        speed = 5;
    }

    IEnumerator voltarNormal(float tempo){
        yield return new WaitForSeconds(tempo);
        invencivel = 0;
    }

    IEnumerator voltarTiroNormal(float tempo){
        yield return new WaitForSeconds(tempo);
        tiroEspecial = 0;
    }

   void OnTriggerEnter2D (Collider2D outro){
    //Caso a variavel invencivel seja 0 o personagem toma dano, caso seja 1 a colisão será ignorada  
        if(invencivel == 0){
            if(outro.gameObject.tag == "batataTag" || outro.gameObject.tag == "pizzaTag" || outro.gameObject.tag == "lancheTag"){
                vidasP = vidasP - 1; 
                AudioSource.PlayClipAtPoint(dano,transform.position);
                if(vidasP==0){
                    Destroy(this.gameObject);
                    SceneManager.LoadScene("menu");
                }
            }
            
            if(outro.gameObject.tag == "ChicleteTag"){
                AudioSource.PlayClipAtPoint(dano,transform.position);
                speed = 1.6f;
                afetado = 1;
                //Inicia um coroutine que espera um tempo para depois atualizar a variavel afetado pra 0 novamente
                // e tambem voltar o valor da velocidade para o normal
                StartCoroutine(desafetar(10f));
            }
        }

        if(outro.gameObject.tag == "escudinhoTag"){
            vidasP = 5;
            Instantiate(escudo, gameObject.transform.position, Quaternion.identity, gameObject.transform);
            AudioSource.PlayClipAtPoint(comer,transform.position);
        }

        if(outro.gameObject.tag == "tomateTag" && vidasP < 7){
            vidasP = vidasP + 1;
            AudioSource.PlayClipAtPoint(comer,transform.position);
        }

        if(outro.gameObject.tag == "brocolisTag"){
            invencivel = 1;
            AudioSource.PlayClipAtPoint(comer,transform.position);
            //Inicia um coroutine que espera um tempo para depois atualizar a variavel invencivel pra 0 novamente
            StartCoroutine(voltarNormal(10f));
        }

        if(outro.gameObject.tag == "morangoTag"){
            tiroEspecial = 1;
            AudioSource.PlayClipAtPoint(comer,transform.position);
            //Inicia um coroutine que espera um tempo para depois atualizar a variavel tiroEspecial pra 0 novamente
            StartCoroutine(voltarTiroNormal(10f));
        }

        Destroy(outro.gameObject);
   }

    public void ImageChange(Sprite newImage){
        //Pega o SpriteRenderer do inspector para alterar o sprite para a nova imagem desejada
        SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = newImage;
    }

    void atualizaPlayer(){
    //Chama a função que altera o sprite do personagem de acordo com a quantidade de vidas
        if(vidasP == 3){
            ImageChange(normal);
        }
        else if(vidasP == 2){
            ImageChange(gordinho);
        }
        else if(vidasP == 1){
            ImageChange(obeso);
        }
    }

}
