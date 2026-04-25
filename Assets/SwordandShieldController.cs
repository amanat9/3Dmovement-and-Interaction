using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordandShieldController : MonoBehaviour
{
    public GameObject Sword;
    public GameObject Shield;
    public bool CanAttack = true;
    public bool AlreadyHit = false;
    public float AttackCooldown = 1.0f;
    public AudioClip SwordSound;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (CanAttack)
            {
                SwordAttack();
            
            }
        }
    }

    public void SwordAttack()
    {
        CanAttack = false;
        Animator anim = Sword.GetComponent<Animator>();

        AudioSource ac = GetComponent<AudioSource>();
        ac.PlayOneShot(SwordSound);

        anim.SetTrigger("sword-attack");
        StartCoroutine(ResetAttackCooldown());
    
    }

    IEnumerator ResetAttackCooldown()
    {

        yield return new WaitForSeconds(AttackCooldown);
        CanAttack = true;
        AlreadyHit = false;
    }

}
