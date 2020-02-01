using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    public float sensitivity;
    public float health;
    
    public CharacterController player;
    public GameObject camera;

    public GameObject startPointOfRay;

    private Ray ray;
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
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("I pressedMouse");
            
            RaycastHit rayHit;
            
            Debug.DrawRay(startPointOfRay.transform.position,startPointOfRay.transform.forward,Color.red,500f);
            if (Physics.Raycast(startPointOfRay.transform.position,startPointOfRay.transform.forward, out rayHit,50))
            {
                Debug.Log("i hit " + rayHit.collider.tag);
                if (rayHit.collider.CompareTag("Enemy"))
                {
                    Debug.Log("I hit an enemy");
                    Enemy component = rayHit.collider.gameObject.GetComponent<Enemy>();
                    component.takeDamage();
                }
            }
            
        }

        moveF = Input.GetAxis("Vertical") * moveSpeed;
        moveB = Input.GetAxis("Horizontal") * moveSpeed;

        rotX = Input.GetAxis("Mouse X") + sensitivity;
        rotY = Input.GetAxis("Mouse Y") + sensitivity;
        
        Vector3 movement = new Vector3(moveB, 0, moveF);
        transform.Rotate(0,rotX,0);
        camera.transform.Rotate(-rotY,0,0);
        startPointOfRay.transform.Rotate(-rotY,0,0);

        movement = transform.rotation * movement;
        player.Move(movement * Time.deltaTime);
        
    }
    
    

    public void takeDamage()
    {
        // health -= 10;
        // if (health <= 0)
        // {
        //     gameObject.SetActive(false);
        // }
    }
}
