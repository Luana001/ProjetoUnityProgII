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
        rb.velocity = new Vector2(direction.x, direction.y).normalized * speed;
    }

    void OnBecameInvisible(){
        Destroy(gameObject);
    }
}
