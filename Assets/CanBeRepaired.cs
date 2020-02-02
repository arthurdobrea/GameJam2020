using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanBeRepaired : MonoBehaviour
{
    private int health;
    private bool repaired = false;
    public static AudioClip workingEngine;
    private static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
        workingEngine = Resources.Load<AudioClip>("workingEngine");
    }
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (repaired)
        {
            if (!audioSrc.isPlaying)
            {
                audioSrc.PlayOneShot(workingEngine);
            }
        }
    }

    public void repair()
    {
        if (health <= 29)
        {
            health += 10;
        }
        else
        {
            repaired = true;
        }
    }

    public bool isRepaired()
    {
        return repaired;
    }
}