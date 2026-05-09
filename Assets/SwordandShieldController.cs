using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordandShieldController : MonoBehaviour
{
    public GameObject Sword;
    public GameObject Shield;
    public bool animBlocking = false; 
    public bool CanAttack = true;
    public bool AlreadyHit = false;
    public float AttackCooldown = 1.0f;
    public AudioClip SwordSound;

    private void Update()
    {
        if (!IsSwordAndShieldEquipped())
        {
            animBlocking = false;
            SetShieldBlocking(false);
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (CanAttack)
            {
                SwordAttack();

            }
        }

        // Blocking logic
        if (Input.GetMouseButton(1))
        {
            animBlocking = true;
            StartCoroutine(ResetAttackCooldown());
        }
        else
        {
            animBlocking = false;
        }

        SetShieldBlocking(animBlocking);

        // what i want to do if  if (Input.GetMouseButtonDown(1)) is held down then animBlocking is set to true. 
        // the animator compnent of Shield i have to SetBool(animBlocking) please do the code. 

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

    private bool IsSwordAndShieldEquipped()
    {
        return Sword != null && Sword.activeInHierarchy && Shield != null && Shield.activeInHierarchy;
    }

    private void SetShieldBlocking(bool isBlocking)
    {
        if (Shield != null)
        {
            Shield.GetComponent<Animator>().SetBool("Blocking", isBlocking);
        }
    }

}
