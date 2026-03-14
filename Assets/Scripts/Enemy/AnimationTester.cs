using UnityEngine;

public class AnimationTester : MonoBehaviour
{
    private Animator anim;
    public bool myIsIdle;
    public bool myIsRunning;
    //public bool myIsIdle;



    void Start()
    {
        // Gets the Animator component attached to this GameObject
        anim = GetComponent<Animator>();
    }

    void Update()
    {


        anim.SetBool("IsIdle", myIsIdle);
        anim.SetBool("IsRunning", myIsRunning);



        // 1. Test "IsIdle" (Press I to toggle)
        if (Input.GetKeyDown(KeyCode.I))
        {
            myIsIdle = true;
            myIsRunning = false;
        }

        // 2. Test "IsRunning" (Hold R to Run, release to stop)
        if (Input.GetKey(KeyCode.O))
        {
            myIsRunning = true;
            myIsIdle = false;
           
        }
        else
        {
            myIsRunning = false;
            myIsIdle = true;
           
        }

        // 3. Test "attack" Trigger (Press Space)
        if (Input.GetKeyDown(KeyCode.P))
        {
            anim.SetTrigger("attack");
          
        }
    }
}