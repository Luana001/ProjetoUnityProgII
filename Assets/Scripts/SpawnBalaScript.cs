using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBalaScript : MonoBehaviour
{
    public Camera Cam;
    private Vector3 PosMouse;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PosMouse = Cam.ScreenToWorldPoint (Input.mousePosition);
        PosMouse.z = transform.position.z;
        transform.up = (PosMouse-transform.position);
    }
}
