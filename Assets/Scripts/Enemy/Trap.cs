using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    [SerializeField] private int trapDamage = 5;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        HealthSystem healthSystem = collision.GetComponent<HealthSystem>();
        if (healthSystem != null)
        {
            bool gotHit = healthSystem.Hit(trapDamage);
            if (gotHit)
            {
                Debug.Log(collision.name + "hit for " + trapDamage);
            }
        }
    }
}
