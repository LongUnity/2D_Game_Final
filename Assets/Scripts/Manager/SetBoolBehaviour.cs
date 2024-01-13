using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetBoolBehaviour : StateMachineBehaviour
{
    [SerializeField] private string parameter;
    [SerializeField] private bool valueOnEnter;
    [SerializeField] private bool valueOnExit;
    [SerializeField] private bool updateOnStateMachine;
    [SerializeField] private bool updateOnState;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool(parameter, valueOnEnter);
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool(parameter, valueOnExit);
    }

    public override void OnStateMachineEnter(Animator animator, int stateMachinePathHash)
    {
        animator.SetBool(parameter, valueOnEnter);
    }

    public override void OnStateMachineExit(Animator animator, int stateMachinePathHash)
    {

        animator.SetBool(parameter, valueOnExit);
    }
}
