using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private AudioSource attackSoundEffect;
    [SerializeField] private int attackDamage = 10;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        HealthSystem healthSystem = collision.GetComponent<HealthSystem>();
        Animator animator = collision.GetComponent<Animator>();
        if (healthSystem != null)
        {
            attackSoundEffect.Play();
            animator.SetTrigger("OnHit");
            bool gotHit = healthSystem.Hit(attackDamage);
            if (gotHit)
            {
                Debug.Log(collision.name + "hit for " + attackDamage);
            }
        }
    }

}
