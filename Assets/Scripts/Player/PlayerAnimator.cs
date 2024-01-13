using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Animator animator;
    private PlayerMovement playerMovement;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void Start()
    {
        GameInput.Instance.OnAttack += Instance_OnAttack;
    }

    private void OnDestroy()
    {
        GameInput.Instance.OnAttack -= Instance_OnAttack;
    }

    private void Instance_OnAttack(object sender, System.EventArgs e)
    {
        animator.SetTrigger("Attack");
    }


    private void Update()
    {
        IdleCheck(GameInput.Instance.GetMoveInputNormalized().x, GameInput.Instance.GetMoveInputNormalized().y);
        HandleAnimation();
    }
    private void IdleCheck(float horizontal, float vertical)
    {
        if (horizontal < 0 || horizontal > 0)
        {
            animator.SetBool("Sideway", true);
            animator.SetBool("Front", false);
            animator.SetBool("Back", false);
        }

        if (vertical < 0)
        {
            animator.SetBool("Sideway", false);
            animator.SetBool("Front", true);
            animator.SetBool("Back", false);
        }

        if (vertical > 0)
        {
            animator.SetBool("Sideway", false);
            animator.SetBool("Front", false);
            animator.SetBool("Back", true);
        }
    }

    private void HandleAnimation()
    {
        animator.SetFloat("Horizontal", GameInput.Instance.GetMoveInputNormalized().x);
        animator.SetFloat("Vertical", GameInput.Instance.GetMoveInputNormalized().y);
        animator.SetFloat("Speed", GameInput.Instance.GetMoveInputNormalized().sqrMagnitude);
    }
}
