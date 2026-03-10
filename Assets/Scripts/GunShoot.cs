using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GunShoot : MonoBehaviour
{

    //Reload
    public float reloadTime;
    public int magazineSize;
        public int bulletleft;
    public bool isReloading;

    //animation 
    private Animator m_Animator;
    //muzzle effect 
    public GameObject muzzleEffect;
 

    public SoundPlayer soundPlayer;
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 30;
    public TextMeshProUGUI enemyText;
    public int enemyDestroyed = 0;
    public float firingDelay = 0f;
    public TextMeshProUGUI AmmoText;

    private void Start()
    {
        //animation 
        m_Animator = GetComponent<Animator>();
        //Reload
        bulletleft = magazineSize;
    }



    private void Update()
    {
        if (Input.GetMouseButton(0) && firingDelay <=0 )
        {
            if (bulletleft > 0)
            {
                fireGun();
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        { 
        
            Reload();
        
        }



        firingDelay = firingDelay - Time.deltaTime;

        enemyText.text = "Enemy Destroyed: " + enemyDestroyed;
        AmmoText.text = "Ammo: " +bulletleft +"/"+ magazineSize;
    }


    private void Reload()
    { 
        isReloading = true;
        Invoke("ReloadCompleted", reloadTime);

    }
    public void ReloadCompleted()
    {
        bulletleft = magazineSize;
        isReloading=false;
    }

    void fireGun()
    {
        bulletleft--;
        //animation 
        m_Animator.SetTrigger("Recoil");
        //muzzle effect 
        muzzleEffect.GetComponent<ParticleSystem>().Play();
        var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        bullet.SetActive(true);
        soundPlayer.PlayGunFire();
        bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * bulletSpeed;
        firingDelay = 0.5f;
    }
}
