using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDead : StateMachineBehaviour
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Time.timeScale = 0;
    }
}
