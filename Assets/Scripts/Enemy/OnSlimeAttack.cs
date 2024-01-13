using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnSlimeAttack : StateMachineBehaviour
{
    SlimeCombat slimeCombat;
    HealthSystem healthSystem;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        slimeCombat = animator.GetComponent<SlimeCombat>();
        healthSystem = animator.GetComponent<HealthSystem>();
        slimeCombat.Speed = 0;
        healthSystem.IsInvincible = true;
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        slimeCombat = animator.GetComponent<SlimeCombat>();
        healthSystem = animator.GetComponent<HealthSystem>();
        slimeCombat.Speed = 1f;
        healthSystem.IsInvincible = false;
    }
}
