using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(HealthSystem))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 5f;

    private Rigidbody2D rb;
    private Animator animator;
    private Vector2 _movement;
    private Vector3 baseScale;
    private HealthSystem healthSystem;
    public Vector2 Movement
    {
        get { return _movement; }
        private set { _movement = value; }
    }


    private bool CanMove
    {
        get { return animator.GetBool("canMove"); }
    }
    public bool IsAlive
    {
        get
        {
            return animator.GetBool("isAlive");
        }
    }
    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        healthSystem = GetComponent<HealthSystem>();
    }

    private void Start()
    {
        baseScale = transform.localScale;
    }

    void Update()
    {
        if (CanMove && IsAlive && !healthSystem.IsHit)
        {
            HandleMovement();
            Flip(GameInput.Instance.GetMoveInputNormalized().x);
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }
    private void Flip(float horizontal)
    {
        if (horizontal < 0)
        {
            transform.localScale = new Vector3(baseScale.x * -1f, baseScale.y, baseScale.z);
        }

        if (horizontal > 0)
        {
            transform.localScale = baseScale;
        }
    }
    private void HandleMovement()
    {
        if (CanMove)
        {
            rb.velocity = GameInput.Instance.GetMoveInputNormalized() * movementSpeed;
        }       
    }
}
