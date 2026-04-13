using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    public AudioSource src;
    public AudioSource EnemySrc;
    public AudioClip GunFire, GunReload;
    public AudioClip EnemyDying;
   


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


    public void PlayEnemyDying()
    {
        EnemySrc.clip = EnemyDying;
        EnemySrc.Play();

    }

}
