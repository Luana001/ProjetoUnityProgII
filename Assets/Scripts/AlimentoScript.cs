using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlimentoScript : MonoBehaviour
{
    public float speed = -2;
    public int forca;
    public int ponto;
    private PontosScript ptScript;

    void Start(){
        ptScript =  GameObject.FindGameObjectWithTag("PontuacaoTag").GetComponent<PontosScript>();
        SetVelocidade();
    }

    void SetVelocidade(){
        Rigidbody2D rb = GetComponent<Rigidbody2D> ();
        rb.velocity = new Vector2(0, speed);
    }

    void OnBecameInvisible() {
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
                ptScript.pontos = ptScript.pontos+ponto;
                Destroy(outro.gameObject);
                Destroy(this.gameObject);
            }
        }
    }

}