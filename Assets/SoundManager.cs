// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
//
// public class SoundManager : MonoBehaviour
// {
//     public static AudioClip playerHitSound, robotHitSound, takeMaterialHitSound, engineFixed, robMoving;
//
//     private static AudioSource audioSrc;
//
//     // Start is called before the first frame update
//     void Start()
//     {
//         playerHitSound = Resources.Load<AudioClip>("playerHitSound");
//         robotHitSound = Resources.Load<AudioClip>("robotHitSound");
//         takeMaterialHitSound = Resources.Load<AudioClip>("takeMaterialHitSound");
//         engineFixed = Resources.Load<AudioClip>("engineFixed");
//         robMoving = Resources.Load<AudioClip>("robMoving");
//
//         audioSrc = GetComponent<AudioSource>();
//     }
//
//     // Update is called once per frame
//     void Update()
//     {
//     }
//
//     public static void playSound(string clip)
//     {
//         switch (clip)
//         {
//             case "playerHitSound":
//             {
//                 audioSrc.PlayOneShot(playerHitSound);
//                 break;
//             }
//             case "robotHitSound":
//             {
//                 audioSrc.PlayOneShot(playerHitSound);
//                 break;
//             }
//             case "takeMaterialHitSound":
//             {
//                 audioSrc.PlayOneShot(playerHitSound);
//                 break;
//             }
//             case "engineFixed":
//             {
//                 audioSrc.PlayOneShot(playerHitSound);
//                 break;
//             }
//             case "robMoving":
//             {
//                 audioSrc.volume = 0.05f;
//                 audioSrc.PlayOneShot(robMoving);
//                 break;
//             }
//         }
//     }
// }