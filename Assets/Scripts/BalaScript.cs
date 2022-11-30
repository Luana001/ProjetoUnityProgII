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
        posMouse = cam.ScreenToWorldPoint (Input.mousePosition);
        posMouse.z = transform.position.z;

        Vector3 direction = posMouse - transform.position;
        transform.up = direction;
        //rb.velocity = new Vector2(transform.position.x, transform.position.y).normalized * speed;

        
        rb.velocity = new Vector2(direction.x, direction.y).normalized * speed;
        
        //Vector3 rotation = transform.position - posMouse;
        //float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.Euler(0, -2.7f, rot+90);


        //Debug.Log("escudo: " + transform.position.y + " " + transform.position.x);
        //Debug.Log("mouse: " + posMouse.y + " " + posMouse.x);
        //Debug.Log(direction.y + " " + direction.x);
        //Debug.Log(rotation.y + " " + rotation.x);
    }

    void OnBecameInvisible(){
        Destroy(gameObject);
    }

  

    void Update()
    {
        
    }
}
