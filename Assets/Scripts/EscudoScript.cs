using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscudoScript : MonoBehaviour
{
    public Sprite IHit;
    public Sprite IIHit;
    public Sprite IIIHit;
    public int vidas = 1;
    public int afetado = 0;
    //public GameObject escudoChiclete;

    void Start()
    {
        gameObject.transform.GetChild(1).gameObject.SetActive(false);
    }

    
    void Update()
    {
        atualizaEscudo();
    }

    public void ImageChange(Sprite newImage){
        SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = newImage;
    }

    IEnumerator esperarTempo(float tempo){
        yield return new WaitForSeconds(tempo);
        afetado=0;
    }

    void OnTriggerEnter2D (Collider2D outro){
        if(outro.gameObject.tag == "batataTag" || outro.gameObject.tag == "pizzaTag" || outro.gameObject.tag == "lancheTag"){
            vidas = vidas - 1;
        }
        else if(outro.gameObject.tag == "ChicleteTag"){
            afetado = 1;
            StartCoroutine(esperarTempo(10f));
        }
        
    }

    void atualizaEscudo(){
        if(vidas == 3){
            ImageChange(IHit);
        }
        else if(vidas == 2){
            ImageChange(IIHit);
        }
        else if(vidas == 1){
            ImageChange(IIIHit);
        }
        else if(vidas == 0){
            Destroy(this.gameObject);
        }

        if(afetado==1){
            //Instantiate(escudoChiclete, transform.position, Quaternion.identity, transform);
            gameObject.transform.GetChild(1).gameObject.SetActive(true); 
        }
        else{
            gameObject.transform.GetChild(1).gameObject.SetActive(false);
            //Destroy(escudoChiclete.gameObject);
        }
    }

    

}
