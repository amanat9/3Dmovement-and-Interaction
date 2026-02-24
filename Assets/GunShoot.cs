using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GunShoot : MonoBehaviour
{
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 30;
    public TextMeshProUGUI enemyText;
    public int enemyDestroyed = 0;
    public float firingDelay = 0f;


    private void Update()
    {
        if (Input.GetMouseButton(0) && firingDelay <=0 )
        {
            var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            bullet.SetActive(true);
            bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * bulletSpeed;
            firingDelay = 0.5f;
        }

        firingDelay = firingDelay - Time.deltaTime;

        enemyText.text = "Enemy Destroyed: " + enemyDestroyed;
    }
}
