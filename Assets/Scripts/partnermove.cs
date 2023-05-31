using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class partnermove : MonoBehaviour
{
    private NavMeshAgent nav;
    public Transform playerPos;
    public PlayerMovement playerChar;
    public bool noRobotDetect;

    Animator animator;



    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame


    void FixedUpdate()
    {
        //Here's the code that checks if the guy is moving. You can use the boolean to set an animator state probably.
        if(nav.velocity.magnitude > 0)
        {
            animator.SetBool("isWalking",true);
        }
        else
        {
            animator.SetBool("isWalking",false);
        }
        if(playerChar.getFreedom() == true)
        {
            nav.destination = playerPos.position;
        }
    }
}
