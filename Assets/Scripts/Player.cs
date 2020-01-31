using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    public float sensitivity;
    private Ray ray;

    public CharacterController player;
    public GameObject camera;

    private float moveF;
    private float moveB;

    private float rotX;
    private float rotY;

    void Start()
    {
        player = GetComponent<CharacterController>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        moveF = Input.GetAxis("Vertical") * moveSpeed;
        moveB = Input.GetAxis("Horizontal") * moveSpeed;

        rotX = Input.GetAxis("Mouse X") + sensitivity;
        rotY = Input.GetAxis("Mouse Y") + sensitivity;
        
        Vector3 movement = new Vector3(moveB, 0, moveF);
        transform.Rotate(0,rotX,0);
        camera.transform.Rotate(-rotY,0,0);

        movement = transform.rotation * movement;
        player.Move(movement * Time.deltaTime);
        
    }
}
