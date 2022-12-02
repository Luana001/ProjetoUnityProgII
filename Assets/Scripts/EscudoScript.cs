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
        gameObject.transform.GetChild(1).gameObject.SetActive(false);
        player = gameObject.GetComponentInParent<PersonagemScript>();
    }

    void Update(){

        if(player.vidasP==4 && vez == 1 || player.vidasP==3 && vez == 1){
            VariaQuebrado();
            vez = 2;
        }

        if(player.vidasP == 5 && vez == 2){
            vez = 1;
        }


        atualizaEscudo();
    }

    public void ImageChange(Sprite newImage){
        SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = newImage;
    }

    void atualizaEscudo(){
        if(player.vidasP == 5){
            ImageChange(ZeroHit);
        }
        else if(player.vidasP == 4){
            ImageChange(first);
        }
        else if(player.vidasP == 3){
            ImageChange(second);
        }
        else if(player.vidasP == 2){
            ImageChange(third);
        }
        else if(player.vidasP == 1){
            Destroy(this.gameObject);
        }

        if(player.afetado==1){
            gameObject.transform.GetChild(1).gameObject.SetActive(true); 
        }
        else{
            gameObject.transform.GetChild(1).gameObject.SetActive(false);
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
