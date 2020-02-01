using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanBeRepaired : MonoBehaviour
{
    private int health;
    private bool repaired = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void repair()
    {
        if (health <= 29)
        {
            health += 10;
        }
        else
        {
            repaired = true;
        }
    }

    public bool isRepaired()
    {
        return repaired;
    }
}
