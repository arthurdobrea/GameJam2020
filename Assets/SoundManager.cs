using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip playerHitSound,
        robotHitSound,
        takeMaterialHitSound,
        engineFixed,
        robMoving,
        punch0,
        punch1,
        punch2,
        die,
        take,
        engine,
        mainTheme;

    private static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        playerHitSound = Resources.Load<AudioClip>("playerHitSound");
        robotHitSound = Resources.Load<AudioClip>("robotHitSound");
        takeMaterialHitSound = Resources.Load<AudioClip>("takeMaterialHitSound");
        engineFixed = Resources.Load<AudioClip>("engineFixed");
        robMoving = Resources.Load<AudioClip>("robMoving");
        punch0 = Resources.Load<AudioClip>("punch0");
        punch1 = Resources.Load<AudioClip>("punch1");
        punch2 = Resources.Load<AudioClip>("punch2");
        die = Resources.Load<AudioClip>("die");
        take = Resources.Load<AudioClip>("take1");
        engine = Resources.Load<AudioClip>("EngineTrying");
        mainTheme = Resources.Load<AudioClip>("mainTheme");

        audioSrc = GetComponent<AudioSource>();
    }

    public static void playSound(string clip)
    {
        switch (clip)
        {
            case "engine": {
                audioSrc.PlayOneShot(engine);
                break;
            }
            case "take": {
                audioSrc.PlayOneShot(take);
                break;
            }
            case "die": {
                audioSrc.PlayOneShot(die);
                break;
            }
            case "hitSound":
            {
                audioSrc.volume = 0.5f;
                int range = Random.Range(1, 3);
                switch (@range)
                {
                    case 1:
                    {
                        audioSrc.PlayOneShot(punch0);
                        break;
                    }
                    case 2:
                    {
                        audioSrc.PlayOneShot(punch1);
                        break;
                    }
                    case 3:
                    {
                        audioSrc.PlayOneShot(punch2);
                        break;
                    }
                }
                break;
            }
            case "takeMaterialHitSound":
            {
                audioSrc.PlayOneShot(playerHitSound);
                break;
            }
            case "engineFixed":
            {
                if (!audioSrc.isPlaying)
                {
                    
                }
                audioSrc.PlayOneShot(playerHitSound);
                break;
            }
            case "robMoving":
            {
                audioSrc.volume = 0.05f;
                if (!audioSrc.isPlaying)
                {
                    audioSrc.PlayOneShot(robMoving);
                }
                break;
            }
        }
    }
}