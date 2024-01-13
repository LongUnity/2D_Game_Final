using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeAttack : MonoBehaviour
{
    [SerializeField] private int attackDamage = 10;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        HealthSystem healthSystem = collision.GetComponent<HealthSystem>();
        if (healthSystem != null )
        {
            bool gotHit = healthSystem.Hit(attackDamage);
            if (gotHit)
            {
                Debug.Log(collision.name + "hit for " + attackDamage);
            }
        }
    }
}
