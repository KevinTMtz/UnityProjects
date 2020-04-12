using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip asteroidEx, enemyEx, playerEx, weaponEne, weaponPla, music;
    static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        asteroidEx = Resources.Load<AudioClip>("Sounds/explosion_asteroid");
        enemyEx = Resources.Load<AudioClip>("Sounds/explosion_enemy");
        playerEx = Resources.Load<AudioClip>("Sounds/explosion_player");
        weaponEne = Resources.Load<AudioClip>("Sounds/weapon_enemy");
        weaponPla = Resources.Load<AudioClip>("Sounds/weapon_player");
        music = Resources.Load<AudioClip>("Sounds/music_background");

        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound (string clip) {
        switch (clip) {
            case"asteroidEx":
                audioSrc.PlayOneShot(asteroidEx, 0.75f);
                break;
            case"enemyEx":
                audioSrc.PlayOneShot(enemyEx, 0.5f);
                break;
            case"playerEx":
                audioSrc.PlayOneShot(playerEx, 0.5f);
                break;
            case"weaponEne":
                audioSrc.PlayOneShot(weaponEne, 0.25f);
                break;
            case"weaponPla":
                audioSrc.PlayOneShot(weaponPla, 0.75f);
                break;
            case"music":
                audioSrc.PlayOneShot(music, 0.5f);
                break;
        }
    }
}
