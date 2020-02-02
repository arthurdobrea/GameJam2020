using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Informable : MonoBehaviour
{

    public String text;

    public Material hig;

    public Material def;
    // Start is called before the first frame update

    private Renderer rb;
    void Start()
    { 
        rb = transform.Find("Parts/Profile").GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.material = def;
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            var selection = hit.transform;

            if (hit.collider.CompareTag("Informable"))
            {
                rb.material = hig;
            }
        }
    }
}
