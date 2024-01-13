using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class OnAwake : StateMachineBehaviour
{
    BossComBat bossComBat;
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        bossComBat = animator.GetComponent<BossComBat>();
        bossComBat.Speed = 1f;
    }

}
