using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip propellerSound, GunSound1, GunSound2;
    public static AudioSource audioSrc;
    void Start()
    {
        propellerSound = Resources.Load<AudioClip>("propellerSound");
        GunSound1 = Resources.Load<AudioClip>("GunSound1");
        GunSound2 = Resources.Load<AudioClip>("GunSound2");
        audioSrc = GetComponent<AudioSource>();
    }


    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "propellerSound":
                audioSrc.PlayOneShot(propellerSound,0.5f);
                break;
            case "GunSound1":
                audioSrc.PlayOneShot(GunSound1);
                break;
            case "GunSound2":
                audioSrc.PlayOneShot(GunSound2);
                break;
        }
    }
    public void StopClip()
    {
        audioSrc.Stop();
    }

}


