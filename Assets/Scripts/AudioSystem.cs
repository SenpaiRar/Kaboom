using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSystem : MonoBehaviour {

    public AudioClip BombCatch;
    public AudioClip BombPass;
    
    AudioSource Source;
	// Use this for initialization
	void Start () {
        Source = GetComponent<AudioSource>();
        Bombs.OnPlayerExplode += PlayBombCatch;
        Bombs.OnExplode += PlayBombPass;
	}
	
    void PlayBombCatch()
    {
        Source.clip = BombCatch;
        Source.Play();
    }

    void PlayBombPass()
    {
        Source.clip = BombPass;
        Source.Play();
    }
}
