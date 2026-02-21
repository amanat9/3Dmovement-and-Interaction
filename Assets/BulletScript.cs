using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float life = 3;
    public GunShoot gunShoot;
    // Start is called before the first frame update
    void Awake()
    {
        Destroy(gameObject, life);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            gunShoot.enemyDestroyed++;
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }

}
