using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

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
    public GameManager gameManager;
    public Image youDied;

    private Animator weaponAnim;

    public Image healthBar;
    private float maxHealth;

    private bool died;

    void Start()
    {
        var tempColor = damageScreen.color;
        tempColor.a = 0f;
        damageScreen.color = tempColor;
        // player = GetComponent<CharacterController>();
        weaponAnim = weapon.GetComponent<Animator>();
        weaponAnim.Play("Idle");
        healthBar.fillAmount = 1.0f;
        maxHealth = health;
        died = false;
    }

    
    void Update()
    {
        if (!died)
        {
            if (!gameManager.mainMenuPanel.activeSelf && !gameManager.settingsPanel.activeSelf)
            {
                if (Input.GetKeyUp(KeyCode.Escape))
                {
                    Cursor.visible = false;
                    gameObject.GetComponent<FirstPersonController>().enabled = true;
                }

                if (Input.GetMouseButtonDown(0))
                {
                    Ray ray = cam.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
                    RaycastHit hit;
                    if (Physics.Raycast(ray, out hit, Mathf.Infinity))
                    {
                        weaponAnim.Play("Attack");
                        if (canAttack)
                        {
                            canAttack = false;
                            Debug.Log("Hello");

                        }

                        StartCoroutine(DoDamage(hit));
                    }
                }
            }
            else
            {
                if (Input.GetKeyUp(KeyCode.Escape))
                {
                    Cursor.visible = true;
                    gameObject.GetComponent<FirstPersonController>().enabled = false;
                }
            }
        }
        else
        {
            StartCoroutine(Restart());
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
    
    IEnumerator FadeIn(Image image)
    {
        float elapsedTime = 0.0f;
        Color c = image.color;
        while (elapsedTime < 3)
        {
            yield return fadeInstruction;
            elapsedTime += Time.deltaTime ;
            c.a = Mathf.Clamp01(elapsedTime / 3);
            image.color = c;
        }
    }

    IEnumerator Restart()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("EngineRoom");
    }

    IEnumerator DoDamage(RaycastHit hit)
    {
        
        float distance = Vector3.Distance(this.transform.position, hit.point);
        if (distance <= 2)
        {
            if (hit.transform.gameObject.tag.Equals("Enemy"))
            {
                SoundManager.playSound("hitSound");
                // SoundManager.playSound("playerHitSound");
                hit.transform.gameObject.GetComponent<Enemy>().TakeDamage(damage);
            }
        }
        yield return new WaitForSeconds(3);
        canAttack = true;
    }

    public void TakeDamage(float damage)
    {
        if (!died)
        {
            health -= damage;
            healthBar.fillAmount = health / maxHealth;
            if (health <= 0)
            {
                died = true;
                StartCoroutine(FadeIn(youDied));
                gameObject.GetComponent<FirstPersonController>().enabled = false;
            }
            StartCoroutine(FadeOut(damageScreen));
        }
    }
}