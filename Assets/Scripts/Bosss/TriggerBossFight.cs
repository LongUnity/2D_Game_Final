using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBossFight : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject healthBar;
    [SerializeField] private GameObject boulder1;
    [SerializeField] private GameObject boulder2;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        animator.SetTrigger("isAwake");
        healthBar.SetActive(true);
        boulder1.SetActive(true);
        boulder2.SetActive(true);
        Destroy(gameObject);
    }
}
