using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour
{

    public GameObject generator;
    public GameObject generator2;

    private CanBeRepaired gen1Repaired;
    private CanBeRepaired gen2Repaired;

    public static int win;
    
    
    // Start is called before the first frame update
    void Start()
    {
        generator = GameObject.Find("generator");
        generator2 = GameObject.Find("generator2");

        gen1Repaired = GetComponent<CanBeRepaired>();
        gen2Repaired = GetComponent<CanBeRepaired>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("desk"))
                {
                    if (Vector3.Distance(transform.position, hit.collider.gameObject.transform.position) < 4)
                    {
                        if (win == 2)
                        {
                            Debug.Log("Win");
                        }
                        else
                        {
                            Debug.Log("Nope");
                        }
                    }
                }
            }
        }
        
    }
}
