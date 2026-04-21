using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetGun : MonoBehaviour
{
    // Type "AK" or "Pistol" in the Unity Inspector for each pickup object
    public string gunName;
    public GunShoot playerGunScript;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
           // GunShoot playerGunScript = collision.gameObject.GetComponent<GunShoot>();

            if (playerGunScript != null)
            {
                // Check the name to unlock the correct gun
                if (gunName == "AK47")
                {
                    playerGunScript.HaveAK47 = true;
                }
                else if (gunName == "Pistol")
                {
                    playerGunScript.HavePistol = true;
                }

                // Destroy the pickup object after collecting it
                Destroy(gameObject);
            }
        }
    }
}