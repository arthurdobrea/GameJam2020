using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Repair : MonoBehaviour
{
    [SerializeField] private Material highlightMaterial;
    [SerializeField] private Material defaultMaterial;
    [SerializeField] private Material repairedMaterial;

    private Transform _selection;

    void Start()
    {
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
                if (hit.collider.CompareTag("Engine"))
                {
                    CanBeRepaired engine = selection.gameObject.GetComponent<CanBeRepaired>();

                    if (myMaterials.canIrepair())
                    {
                        engine.repair();
                    }
                }
            }
        }
    }
}