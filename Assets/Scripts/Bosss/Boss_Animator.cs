using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Animator : MonoBehaviour
{
    [SerializeField] GameObject healthBar;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        animator.SetBool("isAlive", true);
    }

    private void Death()
    {
        HealthSystem enemyHealth = gameObject.GetComponent<HealthSystem>();
        if (enemyHealth.CurrentHealth <= 0)
        {

            animator.SetBool("isAlive", false);
            healthBar.SetActive(false);
        }
    }

    private void Update()
    {
        Death();
    }
}
