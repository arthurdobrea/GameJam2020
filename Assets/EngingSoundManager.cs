using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngingSoundManager : MonoBehaviour
{
    public static AudioClip workingEngine;
    private static AudioSource audioSrc;

    public bool isWorking = false;

    // Start is called before the first frame update
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
        workingEngine = Resources.Load<AudioClip>("workingEngine");
    }

    // Update is called once per frame
    void Update()
    {
        if (isWorking)
        {
            if (!audioSrc.isPlaying)
            {
                audioSrc.PlayOneShot(workingEngine);
            }

        }
    }
}