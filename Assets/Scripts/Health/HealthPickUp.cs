using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUp : MonoBehaviour
{
    [SerializeField] private int healthRestore = 20;
    [SerializeField] private AudioSource healthPickUpSound;
    [SerializeField] private float timeFade = 1f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        HealthSystem healthSystem = collision.GetComponent<HealthSystem>();
        if (healthSystem)
        {
            bool wasHealed = healthSystem.Heal(healthRestore);
            if (wasHealed)
            {
                healthPickUpSound.Play();
                Destroy(gameObject, timeFade);
            }
        }
    }
}
