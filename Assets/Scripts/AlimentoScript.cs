using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlimentoScript : MonoBehaviour
{
    //Classe "Mãe" de outros objetos que o personagem deve acertar
    //Computa os pontos de acordo com o valor de cada filho
    //Também destroi o objeto baseado na vida do objeto filho
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
        //Caso seja a bala comum a variavel força precisa chegar a 0 para o objeto ser destruido e ser contado a pontuação
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

    //Caso o bala seja especial o objeto é destruido automaticamente e os pontos são computados
        else if(outro.gameObject.tag == "BalaEspecialTag"){
            ptScript.pontos = ptScript.pontos+ponto;
            Destroy(outro.gameObject);
            Destroy(this.gameObject);
        }
    }

}
