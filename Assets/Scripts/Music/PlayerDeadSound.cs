using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeadSound : StateMachineBehaviour
{
    AudioSource audioSource;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        audioSource = animator.GetComponent<AudioSource>();
        audioSource.Play();
    }
}