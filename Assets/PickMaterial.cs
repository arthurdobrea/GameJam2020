using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickMaterial : MonoBehaviour
{
    private int countOfMaterials = 0;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("Material"))
                {
                    if (Vector3.Distance(transform.position, hit.collider.gameObject.transform.position) < 4)
                    {
                        countOfMaterials++;
                        Destroy(hit.collider.gameObject);
                    }
                }
            }
        }
    }
}