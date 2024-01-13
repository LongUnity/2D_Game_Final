using JetBrains.Annotations;
using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class HealthSystem : MonoBehaviour
{
    public int MaxHealth
    {
        get { return _maxHealth; }
        set { _maxHealth = value; }
    }
    public int CurrentHealth
    {
        get { return _currentHealth; }
        set
        {
            _currentHealth = value;
            if (_currentHealth <= 0)
            {
                IsAlive = false;
            }
        }
    }
    public bool IsAlive
    {
        get
        {
            return _isAlive;
        }
        set
        {
            _isAlive = value;
            animator.SetBool("isAlive", value);
        }
    }

    public bool IsHit
    {
        get
        {
            return animator.GetBool("isHit");
        }
        private set
        {
            animator.SetBool("isHit", value);
        }
    }

    public bool IsInvincible
    {
        get { return _isInvincible; }
        set { _isInvincible = value; }
    }
    private float timeSinceHit = 0f;
    [SerializeField] private float invincibilityTimer = 0.25f;
    [SerializeField] private bool _isInvincible = false;
    [SerializeField] private bool _isAlive = true;
    [SerializeField] private int _maxHealth = 100;
    [SerializeField] private int _currentHealth;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        CurrentHealth = MaxHealth;
    }
    private void Update()
    {
        if (_isInvincible)
        {
            if (timeSinceHit > invincibilityTimer)
            {
                _isInvincible = false;
                timeSinceHit = 0;
            }
            timeSinceHit += Time.deltaTime;
        }
    }
    public bool Hit(int damage)
    {
        if (IsAlive && !_isInvincible) 
        {
            CurrentHealth -= damage;
            _isInvincible = true;
            IsHit = true;
            CharacterEvents.characterDamaged(gameObject, damage); 
            return true;
        }
        return false;
    }

    public bool Heal(int healthRestore)
    {
        if (IsAlive && CurrentHealth < MaxHealth)
        {
            int maxHeal = Mathf.Max(MaxHealth - CurrentHealth, 0);
            int actualHealth = Mathf.Min(maxHeal, healthRestore);
            Debug.Log(maxHeal + " " + actualHealth + " " + healthRestore);
            CurrentHealth += actualHealth;
            CharacterEvents.characterHealed(gameObject, healthRestore);
            return true;
        }
        else
        {
            return false;
        }
    }

}
