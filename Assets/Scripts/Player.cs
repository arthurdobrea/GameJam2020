using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    public float sensitivity;
    public float health;
    public Image damageScreen;
    public float damage;
    public Camera cam;

    public GameObject weapon;

    private bool canAttack = true;
    
    public CharacterController player;

    public GameObject startPointOfRay;

    private Ray ray;
    private float moveF;
    private float moveB;

    private float rotX;
    private float rotY;

    void Start()
    {
        var tempColor = damageScreen.color;
        tempColor.a = 0f;
        damageScreen.color = tempColor;
        // player = GetComponent<CharacterController>();

    }

    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                weapon.transform.localPosition += Vector3.forward/4;
                StartCoroutine(DoDamage(hit));
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            weapon.transform.localPosition += Vector3.back/4;
        }
    }
    
    
    // Update is called once per frame
    void FixedUpdate()
    {
/*
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, 8)){
                float distance = Vector3.Distance(this.transform.position, hit.point);
                Debug.Log("HERE!");
                if (distance <= 2)
                {
                    if (hit.transform.gameObject.tag.Equals("Enemy"))
                    {
                        hit.transform.gameObject.GetComponent<Enemy>().TakeDamage(damage);
                    }
                }
            }
        }*/
        // if (Input.GetMouseButtonDown(0))
        // {
        //     Debug.Log("I pressedMouse");
        //
        //     RaycastHit rayHit;
        //
        //     Debug.DrawRay(startPointOfRay.transform.position, startPointOfRay.transform.forward, Color.red, 500f);
        //     if (Physics.Raycast(startPointOfRay.transform.position, startPointOfRay.transform.forward, out rayHit, 50))
        //     {
        //         Debug.Log("i hit " + rayHit.collider.tag);
        //         if (rayHit.collider.CompareTag("Enemy"))
        //         {
        //             Debug.Log("I hit an enemy");
        //             Enemy component = rayHit.collider.gameObject.GetComponent<Enemy>();
        //             component.takeDamage();
        //         }
        //     }
        //
        // }
        //
        // moveF = Input.GetAxis("Vertical") * moveSpeed;
        // moveB = Input.GetAxis("Horizontal") * moveSpeed;
        //
        // rotX = Input.GetAxis("Mouse X") + sensitivity;
        // rotY = Input.GetAxis("Mouse Y") + sensitivity;
        //
        // Vector3 movement = new Vector3(moveB, 0, moveF);
        // transform.Rotate(0, rotX, 0);
        // camera.transform.Rotate(-rotY, 0, 0);
        // startPointOfRay.transform.Rotate(-rotY, 0, 0);
        //
        // movement = transform.rotation * movement;
        // player.Move(movement * Time.deltaTime);




    }
    
    private YieldInstruction fadeInstruction = new YieldInstruction();
    IEnumerator FadeOut(Image image)
    {
        float elapsedTime = 0.0f;
        Color c = image.color;
        while (elapsedTime < 3)
        {
            yield return fadeInstruction;
            elapsedTime += Time.deltaTime ;
            c.a = 1.0f - Mathf.Clamp01(elapsedTime / 3);
            image.color = c;
        }
    }
    
    IEnumerator DoDamage(RaycastHit hit)
    {
        float distance = Vector3.Distance(this.transform.position, hit.point);
        if (distance <= 2)
        {
            if (hit.transform.gameObject.tag.Equals("Enemy"))
            {
                if (canAttack)
                {
                    canAttack = false;
                    hit.transform.gameObject.GetComponent<Enemy>().TakeDamage(damage);
                    yield return new WaitForSeconds(1);
                    canAttack = true;
                }
                    
            }
        }
    }

    public void TakeDamage(float damage)
    {
        var tempColor = damageScreen.color;
        tempColor.a = 1f;
        damageScreen.color = tempColor;
        health -= damage;
        if (health <= 0)
        {
            Application.Quit();
        }
        StartCoroutine(FadeOut(damageScreen));
    }
}