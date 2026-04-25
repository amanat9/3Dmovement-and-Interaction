using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AttackPrefabScript : MonoBehaviour
{
    public float life = 3;
    public HealthBar healthBar;
    public SwordandShieldController SSC;
    // Start is called before the first frame update
    void Awake()
    {
        healthBar = GameObject.Find("HealthBar").GetComponent<HealthBar>();
        Destroy(gameObject, life);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player"  && SSC.animBlocking ==false)
        {
            Destroy(gameObject);
            //gunShoot.enemyDestroyed++;
            double updatedHealth = healthBar.healthBarSprite.fillAmount - 0.1;
            healthBar.UpdateHealthBar(updatedHealth);
            //Destroy(collision.gameObject);
            //Destroy(gameObject);
        }
    }

}
