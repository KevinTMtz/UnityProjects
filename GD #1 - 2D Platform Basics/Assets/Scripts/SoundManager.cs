using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip coinS1, coinS2, gameOver1, hit1, jump1, laser1, powerUp1, music1, mStart, mEnd;
    static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        coinS1 = Resources.Load<AudioClip>("c1");
        coinS2 = Resources.Load<AudioClip>("c2");
        gameOver1 = Resources.Load<AudioClip>("go1");
        hit1 = Resources.Load<AudioClip>("h1");
        jump1 = Resources.Load<AudioClip>("j1");
        laser1 = Resources.Load<AudioClip>("l1");
        powerUp1 = Resources.Load<AudioClip>("pu1");
        music1 = Resources.Load<AudioClip>("music");
        mStart = Resources.Load<AudioClip>("musicStart");
        mEnd = Resources.Load<AudioClip>("musicEnd");

        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound (string clip) {
        switch (clip) {
            case"c1":
                audioSrc.PlayOneShot(coinS1);
                break;
            case"c2":
                audioSrc.PlayOneShot(coinS2);
                break;
            case"go1":
                audioSrc.PlayOneShot(gameOver1);
                break;
            case"h1":
                audioSrc.PlayOneShot(hit1);
                break;
            case"j1":
                audioSrc.PlayOneShot(jump1);
                break;
            case"l1":
                audioSrc.PlayOneShot(laser1);
                break;
            case"pu1":
                audioSrc.PlayOneShot(powerUp1);
                break;
            case"music":
                audioSrc.PlayOneShot(music1, 0.25f);
                break;
            case"mStart":
                audioSrc.PlayOneShot(mStart, 0.5f);
                break;
            case"mEnd":
                audioSrc.PlayOneShot(mEnd, 0.5f);
                break;    
        }
    }
}
