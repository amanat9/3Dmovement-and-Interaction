using Ilumisoft.HealthSystem.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float life = 3;
    public GunShoot gunShoot;
    public SoundPlayer soundPlayer;
    public GameObject EnemyPosition;
    public GameObject EnemySelfHealthBar;
    // Start is called before the first frame update
    void Awake()
    {
        Destroy(gameObject, life);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Set position and play sound
            EnemyPosition.transform.position = collision.gameObject.transform.position;
            soundPlayer.PlayEnemyDying();

            // Get the health bar component from the enemy
            var enemyVariables = collision.gameObject.GetComponent<SelfVariables>();

            if (enemyVariables != null && enemyVariables.healthBar != null)
            {
                // Logic for when the enemy has a health bar
                float updatedHealth = enemyVariables.healthBar.healthBarSprite.fillAmount - 0.35f;
                enemyVariables.healthBar.UpdateHealthBar(updatedHealth);

                // Destroy the projectile
                Destroy(gameObject);
            }
            else
            {
                // Logic for when the enemy has no health bar (Instant kill)
                gunShoot.enemyDestroyed++;
                Destroy(collision.gameObject);
                Destroy(gameObject);
            }
        }
    }
}


