﻿using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemy;
    private float timer = 0;
    public float maxValue;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timer >= maxValue)
        {
            Instantiate(enemy, transform.position, transform.rotation);
            timer = 0;
        }
        
        timer += 1 * Time.deltaTime;
        
    }
}
