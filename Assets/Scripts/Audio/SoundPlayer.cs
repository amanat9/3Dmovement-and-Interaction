using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    public AudioSource src;
    public AudioClip GunFire, GunReload;


    public void PlayGunFire()
    {
        src.clip = GunFire;
        src.Play();
    
    }

    public void PlayGunReload()
    {
        src.clip = GunReload;
        src.Play();

    }

}
