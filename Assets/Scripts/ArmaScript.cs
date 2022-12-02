using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmaScript : MonoBehaviour
{
    public GameObject bala;
    public GameObject balaEspecial;
    public GameObject spawnBala;
    public Camera cam;
    private Vector3 posMouse;
    public PersonagemScript player;
    
    void Start()
    {
       cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
       player = gameObject.GetComponentInParent<PersonagemScript>();
    }

    // Update is called once per frame
    void Update()
    {
        posMouse = cam.ScreenToWorldPoint (Input.mousePosition);
        posMouse.z = transform.position.z; 
        transform.up = (posMouse-transform.position);
        Atirar();
    }

    void Atirar()
    {
        if (Input.GetMouseButtonDown(0)) {

            if(player.tiroEspecial==1){
                Instantiate(balaEspecial, spawnBala.transform.position, Quaternion.identity);
            }
            else
                Instantiate(bala, spawnBala.transform.position, Quaternion.identity);
        }
    }
}
