using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Informatino : MonoBehaviour
{
    public GameObject info;
    public GameObject infoCom;
    // Start is called before the first frame update
    void Start()
    {
        info.SetActive(false);
        infoCom.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!info.activeSelf && !infoCom.activeSelf){
            if (Input.GetKeyDown(KeyCode.F))
            {
                var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.CompareTag("Informable"))
                    {
                        if (Vector3.Distance(transform.position, hit.collider.gameObject.transform.position) < 4)
                        {
                            info.SetActive(true);
                            infoCom.SetActive(true);
                            info.GetComponentInChildren<Text>().text = hit.collider.gameObject.GetComponent<Informable>().text;
                            SoundManager.playSound("take");
                        }
                    }
                }
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown(KeyCode.Escape))
            {
                info.SetActive(false);
                infoCom.SetActive(false);
            }
        }
    }
}
