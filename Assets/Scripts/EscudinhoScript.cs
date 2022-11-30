using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscudinhoScript : MonoBehaviour
{
    public float speed = -6;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D> ();
        rb.velocity = new Vector2(0, speed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnBecameInvisible() {
        Destroy(gameObject);
    }
}
