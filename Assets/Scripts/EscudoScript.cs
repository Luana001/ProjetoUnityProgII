using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscudoScript : MonoBehaviour
{
    Sprite first, second, third;
    
    public Sprite ZeroHit;

    //Variação I
    public Sprite IHit, IIHit, IIIHit;

    //Variação II
    public Sprite IHitV2, IIHitV2, IIIHitV2;

    //Variação III
    public Sprite IHitV3, IIHitV3, IIIHitV3;

    //Variação IV
    public Sprite IHitV4, IIHitV4, IIIHitV4;

    public PersonagemScript player;
    private int vez = 1;

    void Start()
    {
        //Desativa (tira) da cena o objeto, que armazena o sprite do escudo afetado 
        gameObject.transform.GetChild(1).gameObject.SetActive(false);
        //Desativa (tira) da cena o objeto, que armazena o sprite do escudo invencivel
        gameObject.transform.GetChild(2).gameObject.SetActive(false);
        player = gameObject.GetComponentInParent<PersonagemScript>();
    }

    void Update(){

        //Chama uma função que define os sprites a serem apresentados nas alterações de escudos quebrados
        //Acontece na primeira vez que o personagem perder uma vida 
        //Ou quando o escudo for instanciado novamente pelo personagem com 5 vidas 
        if(player.vidasP==6 && vez == 1 || player.vidasP==5 && vez == 1){
            VariaQuebrado();
            vez = 2;
        }

        //Chama a função de novo para randomizar os escudos quebrados quando o personagem conseguir todas as vidas novamente
        if(player.vidasP == 7 && vez == 2){
            vez = 1;
        }

        atualizaEscudo();
    }

    public void ImageChange(Sprite newImage){
        //Pega o SpriteRenderer do inspector para alterar o sprite para a nova imagem desejada
        SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = newImage;
    }

    void atualizaEscudo(){
        //Chama a função que altera o sprite do escudo de acordo com a quantidade de vida do personagem
        if(player.vidasP == 7){
            ImageChange(ZeroHit);
        }
        else if(player.vidasP == 6){
            ImageChange(first);
        }
        else if(player.vidasP == 5){
            ImageChange(second);
        }
        else if(player.vidasP == 4){
            ImageChange(third);
        }
        else if(player.vidasP == 3){
            Destroy(this.gameObject);
        }

        //Ativa na cena o objeto na cena que armazena o sprite do escudo afetado
        //E desativa quando a variavel voltar a ser 0
        if(player.afetado==1){
            gameObject.transform.GetChild(1).gameObject.SetActive(true); 
        }
        else{
            gameObject.transform.GetChild(1).gameObject.SetActive(false);
        }

        //Ativa na cena o objeto na cena que armazena o sprite do escudo invencivel
        //E desativa quando a variavel voltar a ser 0
        if(player.invencivel==1){
            gameObject.transform.GetChild(2).gameObject.SetActive(true);
        }
        else{
            gameObject.transform.GetChild(2).gameObject.SetActive(false);
        }
    }

    void QuebradoV1(){
        first = IHit;
        second = IIHit;
        third = IIIHit;
    }

    void QuebradoV2(){
        first = IHitV2;
        second = IIHitV2;
        third = IIIHitV2;
    }
    
    void QuebradoV3(){
        first = IHitV3;
        second = IIHitV3;
        third = IIIHitV3;
    }

    void QuebradoV4(){
        first = IHitV4;
        second = IIHitV4;
        third = IIIHitV4;
    }

    void VariaQuebrado(){
     int vez = Random.Range(1,5);

      switch(vez){
         case 1: 
             QuebradoV1();
            break;
         case 2:
            QuebradoV2();
            break;
         case 3: 
            QuebradoV3();
            break;
        case 4: 
            QuebradoV4();
            break;
        }
    }
    

}
