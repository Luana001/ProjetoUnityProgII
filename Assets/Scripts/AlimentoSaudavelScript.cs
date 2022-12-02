using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlimentoSaudavelScript : MonoBehaviour
{
    public float speed = -2;

    void Start(){
        SetVelocidade();
    }

    void SetVelocidade(){
        Rigidbody2D rb = GetComponent<Rigidbody2D> ();
        rb.velocity = new Vector2(0, speed);
    }

    void OnBecameInvisible() {
        Destroy(gameObject);
    }
}
