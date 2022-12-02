using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaScript : MonoBehaviour
{
    public float speed = 8;
    public Camera cam;
    private Vector3 posMouse;

    void Start(){
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        //Pega a posição do mouse na cena e passa para o vetor 
        posMouse = cam.ScreenToWorldPoint (Input.mousePosition);
       
        //Fixa a posição no eixo z para não movimentar nesse eixo 
        posMouse.z = transform.position.z; 

        //Modifica a posição da bala para a direção da posição do mouse
        Vector3 direction = posMouse - transform.position;
        transform.up = direction;

        //Configura velocity para ir na direção do mouse
        rb.velocity = new Vector2(direction.x, direction.y).normalized * speed;
    }

    void OnBecameInvisible(){
        Destroy(gameObject);
    }
}
