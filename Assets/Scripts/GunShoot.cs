using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GunShoot : MonoBehaviour
{
    private const string PistolWeapon = "Pistol";
    private const string AK47Weapon = "AK47";
    private const string SwordAndShieldWeapon = "SwordAndShield";

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
    public string currentGun = "Pistol"; // other options: AK47, SwordAndShield


    public SoundPlayer soundPlayer;
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 30;
    public TextMeshProUGUI enemyText;
    public int enemyDestroyed = 0;
    public float firingDelay = 0f;
    public float firingDelayValue = 0.5f;
    public TextMeshProUGUI AmmoText;

    [Header("Optional Auto-UI Lookup")]
    public string enemyTextObjectName = "EnemyText";
    public string ammoTextObjectName = "AmmoText";

    private void Start()
    {
        //animation 
        m_Animator = GetComponent<Animator>();
        EquipCurrentWeapon();
        RefreshSceneUIReferences();
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        RefreshSceneUIReferences();
    }

    private void RefreshSceneUIReferences()
    {
        if (enemyText == null)
        {
            GameObject enemyTextObject = GameObject.Find(enemyTextObjectName);
            if (enemyTextObject != null)
            {
                enemyText = enemyTextObject.GetComponent<TextMeshProUGUI>();
            }
        }

        if (AmmoText == null)
        {
            GameObject ammoTextObject = GameObject.Find(ammoTextObjectName);
            if (ammoTextObject != null)
            {
                AmmoText = ammoTextObject.GetComponent<TextMeshProUGUI>();
            }
        }
    }



    private void Update()
    {
        // Weapon switching input
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SwitchWeapon();
        }

        if (IsUsingGun() && Input.GetButton("Fire1") && firingDelay <=0)    //Input.GetButton("Fire1")    Input.GetMouseButton(0)
        {
            if (bulletleft > 0)
            {
                fireGun();
            }
        }

        if (IsUsingGun() && Input.GetKeyDown(KeyCode.R))
        { 
        
            Reload();
        
        }



        firingDelay = firingDelay - Time.deltaTime;

        if (enemyText != null)
        {
            enemyText.text = "Enemy Destroyed: " + enemyDestroyed;
        }

        if (AmmoText != null)
        {
            if (IsUsingGun())
            {
                AmmoText.text = "Ammo: " + bulletleft + "/" + magazineSize;
            }
            else
            {
                AmmoText.text = "Sword & Shield";
            }
        }
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
        if (!IsUsingGun())
        {
            return;
        }

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
        CancelReload();

        if (currentGun == PistolWeapon)
        {
            if (HaveAK47 == true)
            {
                EquipAK47Stats();
            }
            else
            {
                EquipSwordAndShieldStats();
            }
        }
        else if (currentGun == AK47Weapon)
        {
            EquipSwordAndShieldStats();
        }
        else
        {
            if (HavePistol == true)
            {
                EquipPistolStats();
            }
            else if (HaveAK47 == true)
            {
                EquipAK47Stats();
            }
        }
    }

    public void EquipPistolStats()
    {
        currentGun = PistolWeapon;
        SetWeaponActive(gunAK47, false);
        SetWeaponActive(gunPistol, true);
        SetWeaponActive(Sword, false);
        SetWeaponActive(Shield, false);

        // Apply Pistol Stats
        bulletSpeed = 30f;
        firingDelayValue = 0.5f;
        magazineSize = 7;
        bulletleft = magazineSize;
    }

    public void EquipAK47Stats()
    {
        currentGun = AK47Weapon;
        SetWeaponActive(gunPistol, false);
        SetWeaponActive(gunAK47, true);
        SetWeaponActive(Sword, false);
        SetWeaponActive(Shield, false);

        // Apply AK47 Stats
        bulletSpeed = 50f;
        firingDelayValue = 0.3f;
        magazineSize = 30;
        bulletleft = magazineSize;
    }

    public void EquipSwordAndShieldStats()
    {
        currentGun = SwordAndShieldWeapon;
        SetWeaponActive(gunPistol, false);
        SetWeaponActive(gunAK47, false);
        SetWeaponActive(Sword, true);
        SetWeaponActive(Shield, true);

        firingDelay = 0f;
        bulletleft = 0;
    }

    private void EquipCurrentWeapon()
    {
        if (currentGun == AK47Weapon && HaveAK47 == true)
        {
            EquipAK47Stats();
        }
        else if (currentGun == SwordAndShieldWeapon)
        {
            EquipSwordAndShieldStats();
        }
        else if (HavePistol == true)
        {
            EquipPistolStats();
        }
        else if (HaveAK47 == true)
        {
            EquipAK47Stats();
        }
        else
        {
            EquipSwordAndShieldStats();
        }
    }

    private void CancelReload()
    {
        if (isReloading)
        {
            isReloading = false;
            CancelInvoke("ReloadCompleted");
        }
    }

    private bool IsUsingGun()
    {
        return currentGun == PistolWeapon || currentGun == AK47Weapon;
    }

    private void SetWeaponActive(GameObject weapon, bool isActive)
    {
        if (weapon != null)
        {
            weapon.SetActive(isActive);
        }
    }




}
