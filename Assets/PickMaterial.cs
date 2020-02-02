using UnityEngine;

public class PickMaterial : MonoBehaviour
{
    private static int countOfMaterials = 0;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("Material"))
                {
                    if (Vector3.Distance(transform.position, hit.collider.gameObject.transform.position) < 4)
                    {
                        SoundManager.playSound("take");
                        countOfMaterials += 2;
                        Destroy(hit.collider.gameObject);
                    }
                }
            }
        }
    }

    public bool canIrepair()
    {
        if (countOfMaterials > 0)
        {
            countOfMaterials -= 1;
            return true;
        }
        else
        {
            return false;
        }
    }

    public static bool repairMySelf()
    {
        if (countOfMaterials > 0)
        {
            countOfMaterials -= 1;
            return true;
        }
        else
        {
            return false;
        }
    }
}