

//public class AnimationTestEnemies : MonoBehaviour



using UnityEngine;

public class AnimationTestEnemies : MonoBehaviour
{
    private Animator anim;

    void Start()
    {
        // This gets the Animator component attached to your character
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        // 1. Handle Trigger: Attack
        // Press SPACE to trigger the attack
        if (Input.GetKeyDown(KeyCode.I))
        {
            anim.SetTrigger("attack");
        }

        // 2. Handle Bool: IsRunning
        // Hold LEFT SHIFT to "Run", let go to stop
        if (Input.GetKeyDown(KeyCode.O))
        {
            anim.SetBool("IsRunning", true);
            anim.SetBool("IsIdle", false);
        }
        if (Input.GetKeyUp(KeyCode.O))
        {
            anim.SetBool("IsRunning", false);
        }

        // 3. Handle Bool: IsIdle
        // Press 'I' to toggle Idle mode manually
        if (Input.GetKeyDown(KeyCode.P))
        {
            // This toggles the bool to whatever it currently ISN'T
            //bool currentIdle = anim.GetBool("IsIdle");
            anim.SetBool("IsIdle", true);
            anim.SetBool("IsRunning", false);
        }
    }
}
