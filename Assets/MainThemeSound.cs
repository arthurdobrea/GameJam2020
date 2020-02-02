using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainThemeSound : MonoBehaviour
{
    public static AudioClip mainTheme;
    private static AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        mainTheme = Resources.Load<AudioClip>("mainTheme");
        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!audioSrc.isPlaying)
        {
            audioSrc.PlayOneShot(mainTheme);
        }

    }
}
