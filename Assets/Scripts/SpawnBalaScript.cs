using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBalaScript : MonoBehaviour
{
    //GameObject invisivel feito para definir o local de spawn da bala
    public Camera Cam;
    private Vector3 PosMouse;

    void Update()
    {
        PosMouse = Cam.ScreenToWorldPoint (Input.mousePosition);
        PosMouse.z = transform.position.z;
        transform.up = (PosMouse-transform.position);
    }
}
