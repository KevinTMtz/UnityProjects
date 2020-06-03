using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.Audio;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public Sound[] sounds;
    
    public static AudioClip chain, jump, positive, dead, gameOver, coin, youWin;
    static AudioSource audioSrc;

    public static SoundManager instance;

    void Awake() {
        if (instance == null)
            instance = this;
        else {
            Destroy(gameObject);
            return;
        }  

        DontDestroyOnLoad(gameObject);  

        foreach (Sound s in sounds) {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.loop = s.loop;
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        chain = Resources.Load<AudioClip>("Sounds/chain");
        jump = Resources.Load<AudioClip>("Sounds/jump_26");
        positive = Resources.Load<AudioClip>("Sounds/positive");
        dead = Resources.Load<AudioClip>("Sounds/game_over_13");
        gameOver = Resources.Load<AudioClip>("Sounds/game_over_02");
        coin = Resources.Load<AudioClip>("Sounds/coin_04");
        youWin = Resources.Load<AudioClip>("Sounds/coin_30");

        audioSrc = GetComponent<AudioSource>();
    }

    // FindObjectOfType<SoundManager>().Play("SongName");
    // SoundManager.PlaySound("SongName");
    // FindObjectOfType<SoundManager>().StopPlaying("sound string name");

    public void Play(string name) {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        
        if (s == null) {
            Debug.Log("Not found: " + name);
            return;
        }
        
        s.source.Play();
    }

    public void StopPlaying (string sound) {
        Sound s = Array.Find(sounds, item => item.name == sound);
        
        if (s == null) {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }

        s.source.Stop();
    }

    public void StopAllSongs () {
        for (int i=0; i<sounds.Length; i++) {
            sounds[i].source.Stop();
        }
    }
    
    public static void PlaySound (string clip) {
        switch (clip) {
            case "Chain":
                audioSrc.PlayOneShot(chain, 0.2f);
                break;
            case "Jump":
                audioSrc.PlayOneShot(jump, 0.75f);
                break;
            case "Positive":
                audioSrc.PlayOneShot(positive, 1f);
                break;
            case "Dead":
                audioSrc.PlayOneShot(dead, 1f);
                break;
            case "GameOver":
                audioSrc.PlayOneShot(gameOver, 1f);
                break;
            case "Coin":
                audioSrc.PlayOneShot(coin, 1f);
                break;
            case "Win":
                audioSrc.PlayOneShot(youWin, 1f);
                break;
        }
    }
}
