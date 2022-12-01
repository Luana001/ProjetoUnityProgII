using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChicleteScript : MonoBehaviour
{
    public float speed = 4;
    void Start()
    {
        SetVelocidade();
    }

   
    void Update()
    {
        
    }

    public void setLado(int lado){
        if(lado==2){
            speed = speed*-1;
        }
    }
    
    void SetVelocidade(){
        Rigidbody2D rb = GetComponent<Rigidbody2D> ();
        rb.velocity = new Vector2(speed, 0);
    }

    void OnBecameInvisible(){
        Destroy(gameObject);
    }
}
