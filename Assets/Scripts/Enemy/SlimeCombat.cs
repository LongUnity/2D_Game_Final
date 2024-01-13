using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeCombat : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float lineOfSight;
    [SerializeField] private float attackRange;
    [SerializeField] private Transform player;
    private Animator animator;
    private float distanceFromPlayer;

    public float Speed
    {
        get
        {
            return _speed;
        }
        set
        {
            _speed = value;
        }
    }

    public bool IsAlive
    {
        get
        {
            return animator.GetBool("isAlive");
        }
    }

    public float AttackCoolDown
    {
        get
        {
            return animator.GetFloat("attackCoolDown");
        }
        private set
        {
            animator.SetFloat("attackCoolDown", Mathf.Max(value, 0));
        }
    }

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if (IsAlive)
        {
            HandlePatrol();
        }
        if (AttackCoolDown > 0)
        {
            AttackCoolDown -= Time.deltaTime;
        }
    }

    private void HandlePatrol()
    {
        distanceFromPlayer = Vector2.Distance(player.position, transform.position);
        if (distanceFromPlayer < lineOfSight && distanceFromPlayer > attackRange)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.position, _speed * Time.deltaTime);
        }
        if (distanceFromPlayer <= attackRange)
        {
            animator.SetTrigger("Attack");
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, lineOfSight);
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}