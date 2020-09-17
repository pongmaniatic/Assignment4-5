using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip propellerSound, bullet1Sound, bullet2Sound;
    static AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        propellerSound = Resources.Load<AudioClip>(" dsf");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
