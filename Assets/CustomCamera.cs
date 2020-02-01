using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomCamera : MonoBehaviour
{
    public bool collisionDebug;
    public LayerMask collisionMask;
    private Ray camRay;
    private RaycastHit camRayHit;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CameraCollisions()
    {
        camRay.origin = transform.position;
        // tils
    }
}
