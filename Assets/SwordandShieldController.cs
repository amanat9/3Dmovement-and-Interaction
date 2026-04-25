using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordandShieldController : MonoBehaviour
{
    public GameObject Sword;
    public GameObject Shield;
    public bool CanAttack = true;
    public float AttackCooldown = 1.0f;

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
        anim.SetTrigger("sword-attack");
        StartCoroutine(ResetAttackCooldown());
    
    }

    IEnumerator ResetAttackCooldown()
    {

        yield return new WaitForSeconds(AttackCooldown);
        CanAttack = true;
    }

}
