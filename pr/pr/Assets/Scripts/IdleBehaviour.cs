using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleBehaviour : StateMachineBehaviour
{
    float timer;
    Transform player;
    float runRange = 15;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = 0;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }


    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer += Time.deltaTime;
        if (timer > 5)
            animator.SetBool("isPatrolling", true);

        float distance = Vector3.Distance(animator.transform.position, player.position);
        if (distance < runRange)
            animator.SetBool("isRunning", true);
    }


    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

}
