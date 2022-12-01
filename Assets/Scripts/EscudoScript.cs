using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscudoScript : MonoBehaviour
{
    Sprite first, second, third;

    //Variação I
    public Sprite IHit, IIHit, IIIHit;

    //Variação II
    public Sprite IHitV2, IIHitV2, IIIHitV2;

    //Variação III
    public Sprite IHitV3, IIHitV3, IIIHitV3;

    //Variação IV
    public Sprite IHitV4, IIHitV4, IIIHitV4;

    public int vidas = 4;
    public int afetado = 0;
    //public GameObject escudoChiclete;

    void Start()
    {
        gameObject.transform.GetChild(1).gameObject.SetActive(false);
    }

    public void ImageChange(Sprite newImage){
        SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = newImage;
    }

    IEnumerator esperarTempo(float tempo){
        atualizaEscudoChiclete();
        yield return new WaitForSeconds(tempo);
        afetado=0;
        atualizaEscudoChiclete();
    }

    void OnTriggerEnter2D (Collider2D outro){
        if(outro.gameObject.tag == "batataTag" || outro.gameObject.tag == "pizzaTag" || outro.gameObject.tag == "lancheTag"){
            vidas = vidas - 1;
        }
        else if(outro.gameObject.tag == "ChicleteTag"){
            afetado = 1;
            StartCoroutine(esperarTempo(10f));
        }

        if(vidas==3 && afetado==0){
            VariaQuebrado();
        }

        atualizaEscudo();
        
    }

    void atualizaEscudo(){
        if(vidas == 3){
            ImageChange(first);
        }
        else if(vidas == 2){
            ImageChange(second);
        }
        else if(vidas == 1){
            ImageChange(third);
        }
        else if(vidas == 0){
            Destroy(this.gameObject);
        }
    }

    void atualizaEscudoChiclete(){
        if(afetado==1){
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
