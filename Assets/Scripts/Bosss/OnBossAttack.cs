using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnBossAttack : StateMachineBehaviour
{
    BossComBat bossComBat;
    HealthSystem healthSystem;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        bossComBat = animator.GetComponent<BossComBat>();
        healthSystem = animator.GetComponent<HealthSystem>();
        bossComBat.Speed = 0f;
        healthSystem.IsInvincible = true;
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        bossComBat = animator.GetComponent<BossComBat>();
        bossComBat.Speed = 1f;
        healthSystem.IsInvincible = false;
    }
}
