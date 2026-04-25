using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordDamage : MonoBehaviour
{
    public SwordandShieldController SSC;
    public SoundPlayer soundPlayer;

    private void OnCollisionEnter(Collision collision)
    {
        if ((collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("WeakPoint")) && SSC.AlreadyHit ==false)
        {
            // Set position and play sound
            SSC.AlreadyHit = true;
            soundPlayer.PlayEnemyDying();

            // Get the health bar component from the enemy
            var enemyVariables = collision.gameObject.GetComponent<SelfVariables>();

            if (enemyVariables != null && enemyVariables.healthBar != null)
            {

                if (collision.gameObject.CompareTag("WeakPoint"))
                {
                    // Logic for when the enemy has a health bar
                    float updatedHealth = enemyVariables.healthBar.healthBarSprite.fillAmount - 1.00f;
                    enemyVariables.healthBar.UpdateHealthBar(updatedHealth);

                    // Destroy the projectile
                    //Destroy(gameObject);
                }
                else
                {
                    // Logic for when the enemy has a health bar
                    float updatedHealth = enemyVariables.healthBar.healthBarSprite.fillAmount - 0.35f;
                    enemyVariables.healthBar.UpdateHealthBar(updatedHealth);

                    // Destroy the projectile
                    //Destroy(gameObject);
                }
            }
            else
            {
                // Logic for when the enemy has no health bar (Instant kill)
               // gunShoot.enemyDestroyed++;
                Destroy(collision.gameObject);
                //Destroy(gameObject);
            }
        }
    }


}
