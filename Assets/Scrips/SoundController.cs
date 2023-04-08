using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    private AudioSource soundSiu;
    
    public static SoundController Instance;

    

    private void Start() {
        Instance = this;
        soundSiu = GetComponent<AudioSource>();
    }

    public void EjecutarSonido(AudioClip sonido) {
        soundSiu.PlayOneShot(sonido);

    }


    

    
}
