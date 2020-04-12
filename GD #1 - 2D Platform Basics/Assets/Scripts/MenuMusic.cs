using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMusic : MonoBehaviour
{
    public bool musicCheck = true;

    // Update is called once per frame
    void Update()
    {
        if (musicCheck && gameObject.tag.Equals("StartMenu")) {
            SoundManager.PlaySound("mStart");
            musicCheck = false;
        } else if (musicCheck && gameObject.tag.Equals("EndMenu")) {
            SoundManager.PlaySound("mEnd");
            musicCheck = false;
        }
    }
}
