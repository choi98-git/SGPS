using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair2 : MonoBehaviour
{
    SpriteRenderer sr;
    public GameObject go;
    void Start()
    {
        sr = go.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("p"))
            sr.material.color = Color.red;
    }
}
