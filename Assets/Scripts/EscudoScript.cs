using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EscudoScript : MonoBehaviour
{
    public Sprite IHit;
    public Sprite IIHit;
    public Sprite IIIHit;
    public int vidas = 4;

    void Start()
    {
        
    }

    
    void Update()
    {

    }

    public void ImageChange(Sprite newImage){
        SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = newImage;
    }

    void OnTriggerEnter2D (Collider2D outro){
        if(outro.gameObject.tag == "batataTag" || outro.gameObject.tag == "pizzaTag" || outro.gameObject.tag == "lancheTag"){
            vidas = vidas - 1;
        }
        if(vidas == 3){
            //SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
            //spriteRenderer.sprite = IHit;
            ImageChange(IHit);

        }
        else if(vidas == 2){
            //SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
            //spriteRenderer.sprite = IIHit;
            ImageChange(IIHit);
        }
        else if(vidas == 1){
            //SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
            //spriteRenderer.sprite = IIIHit;
            ImageChange(IIIHit);
        }
        else if(vidas == 0){
            Destroy(this.gameObject);
            //transform.position = new Vector3(transform.position.x, -7f, transform.position.z);
        }
        
    }

    

}
