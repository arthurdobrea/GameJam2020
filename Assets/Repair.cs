using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class Repair : MonoBehaviour
{
    [SerializeField] private Material highlightMaterial;
    [SerializeField] private Material defaultMaterial;
    [SerializeField] private Material repairedMaterial;

    private Transform _selection;

    public GameObject winc;
    
    public Image winImage;
    


    void Start()
    {
    }
    
    private YieldInstruction fadeInstruction = new YieldInstruction();

    IEnumerator FadeIn(Image image)
    {
        float elapsedTime = 0.0f;
        Color c = image.color;
        while (elapsedTime < 3)
        {
            yield return fadeInstruction;
            elapsedTime += Time.deltaTime;
            c.a = Mathf.Clamp01(elapsedTime / 3);
            image.color = c;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (_selection != null)
        {
            var selectionRenderer = _selection.GetComponent<Renderer>();
            selectionRenderer.material = defaultMaterial;
            _selection = null;
        }

        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            var selection = hit.transform;

            if (hit.collider.CompareTag("Engine"))
            {
                var selectionRenderer = selection.GetComponent<Renderer>();
                if (selectionRenderer != null)
                {
                    CanBeRepaired engine = selection.gameObject.GetComponent<CanBeRepaired>();

                    if (engine.isRepaired())
                    {
                        selectionRenderer.material = repairedMaterial;
                    }
                    else
                    {
                        selectionRenderer.material = highlightMaterial;
                    }
                }

                _selection = selection;
            }

            if (hit.collider.CompareTag("desk"))
            {
                var selectionRenderer = selection.GetComponent<Renderer>();
                if (selectionRenderer != null)
                {
                    CanBeRepaired engine = selection.gameObject.GetComponent<CanBeRepaired>();

                    if (winc.GetComponent<WinCondition>().win == 2)
                    {
                        selectionRenderer.material = repairedMaterial;
                    }
                    else
                    {
                        selectionRenderer.material = highlightMaterial;
                    }
                }

                _selection = selection;
            }

            if (Physics.Raycast(ray, out hit))
            {
                selection = hit.transform;

                if (hit.collider.CompareTag("Material"))
                {
                    var selectionRenderer = selection.GetComponent<Renderer>();
                    if (selectionRenderer != null)
                    {
                        selectionRenderer.material = highlightMaterial;
                    }

                    _selection = selection;
                }
            }

            PickMaterial myMaterials = gameObject.GetComponent<PickMaterial>();
            
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.CompareTag("desk"))
                    {
                        if (Vector3.Distance(transform.position, hit.collider.gameObject.transform.position) < 4)
                        {
                            if (winc.GetComponent<WinCondition>().win == 2)
                            {
                                StartCoroutine(FadeIn(winImage));
                                transform.GetComponent<FirstPersonController>().enabled = false;
                                if (Input.GetKeyDown(KeyCode.Escape))
                                {
                                    Application.Quit();
                                }
                            }
                            else
                            {
                                Debug.Log("Nope");
                            }
                        }
                    }
                }
            }

            if (Input.GetKeyDown(KeyCode.F))
            {
                if (hit.collider.CompareTag("Engine"))
                {
                    CanBeRepaired engine = selection.gameObject.GetComponent<CanBeRepaired>();

                    if (myMaterials.canIrepair())
                    {
                        SoundManager.playSound("engine");
                        engine.repair();
                    }
                }
            }
        }
    }
}