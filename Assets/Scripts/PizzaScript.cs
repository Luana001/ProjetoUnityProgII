using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaScript : MonoBehaviour
{
    public float speed = -6;
    public int forca = 3;

    void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, speed);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D outro)
    {
        if (outro.gameObject.tag == "BalaTag")
        {
            if (forca > 0)
            {
                Destroy(outro.gameObject);
                forca--;
            }
            if (forca == 0)
            {
                Destroy(outro.gameObject);
                Destroy(this.gameObject);
            }


            //Adicionar pontuacao
        }

    }
}

