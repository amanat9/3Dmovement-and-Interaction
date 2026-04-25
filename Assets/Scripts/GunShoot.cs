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

    public GameObject Sword;
    public GameObject Shield; 
    //pistol, bullet speed 30, firing delay 0.5, magazine size 7
    //ak, bullet speed 50, firing delay 0.3, magazine size 30
    public GameObject gunPistol;
    public bool HavePistol=true;
    public GameObject gunAK47;
    public bool HaveAK47=false;
    public string currentGun = "Pistol"; // other option : AK47


    public SoundPlayer soundPlayer;
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 30;
    public TextMeshProUGUI enemyText;
    public int enemyDestroyed = 0;
    public float firingDelay = 0f;
    public float firingDelayValue = 0.5f;
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
        // Weapon switching input
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SwitchWeapon();
        }

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
        firingDelay = firingDelayValue;
    }




    ////////////////////////////////////// SWITCH WEAPONS/////////////////////////////////////
    ///

    private void SwitchWeapon()
    {
        // Cancel any ongoing reloads when switching weapons
        if (isReloading)
        {
            isReloading = false;
            CancelInvoke("ReloadCompleted");
        }

        // Check which gun is active and if the player actually owns the other gun
        if (currentGun == "Pistol" && HaveAK47 == true)
        {
            EquipAK47Stats();
        }
        else if (currentGun == "AK47" && HavePistol == true)
        {
            EquipPistolStats();
        }
    }

    private void EquipPistolStats()
    {
        currentGun = "Pistol";
        gunAK47.SetActive(false);
        gunPistol.SetActive(true);

        // Apply Pistol Stats
        bulletSpeed = 30f;
        firingDelayValue = 0.5f;
        magazineSize = 7;
        bulletleft = magazineSize;
    }

    private void EquipAK47Stats()
    {
        currentGun = "AK47";
        gunPistol.SetActive(false);
        gunAK47.SetActive(true);

        // Apply AK47 Stats
        bulletSpeed = 50f;
        firingDelayValue = 0.3f;
        magazineSize = 30;
        bulletleft = magazineSize;
    }





}
