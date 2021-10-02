using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audio : MonoBehaviour
{

    public AudioSource Sound;
    public AudioClip mainmenusound;
    void Start()
    {
        Sound = GetComponent<AudioSource>();
        Sound.clip = mainmenusound;
        Sound.Play();
    }

  
}
