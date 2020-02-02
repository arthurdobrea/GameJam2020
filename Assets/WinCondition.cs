using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class WinCondition : MonoBehaviour
{

    private CanBeRepaired gen1Repaired;
    private CanBeRepaired gen2Repaired;

    public int win = 0;

    
    
    
    // Start is called before the first frame update
    void Start()
    {
        gen1Repaired = GetComponent<CanBeRepaired>();
        gen2Repaired = GetComponent<CanBeRepaired>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
    
    
}
