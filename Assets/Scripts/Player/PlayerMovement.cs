using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    [Header("Ground Check")]
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;
    private bool isGrounded;

    private int facingDirection;

    private Animator anim;
    private Rigidbody2D rb;
    private Vector2 moveVal;
    private bool canDash;
    private bool isDashing;

    [Header("Jumps")]
    public int extraJumps = 1;
    public int totalExtraJumps = 1;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        canDash = true;
        extraJumps = totalExtraJumps;
    }

    void Update()
    {
        anim.SetFloat("horizontal", Mathf.Abs(moveVal.x));
        anim.SetFloat("vertical", Mathf.Abs(moveVal.y));
        
        if(moveVal.x > 0 && transform.localScale.x < 0 ||
                moveVal.x < 0 && transform.localScale.x > 0)
        {
            Flip();
        }
        if(!isDashing)
        {
            rb.linearVelocity = new Vector2(moveVal.x * StatsManager.Instance.moveSpeed, rb.linearVelocity.y);
        }
        if(isGrounded)
        {
            extraJumps = totalExtraJumps;
        }
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }

    void OnMove(InputValue value)
    {
        moveVal = value.Get<Vector2>();
    }

    void OnJump()
    {
        if(isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, StatsManager.Instance.jumpForce);
        }
        else if(extraJumps > 0)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, StatsManager.Instance.jumpForce);
            extraJumps--;
        }
    }

    void OnDash()
    {
        if(canDash)
        {
            isDashing = true;
            canDash = false;
            rb.constraints |= RigidbodyConstraints2D.FreezePositionY;

            Vector2 dashDirection = new Vector2(moveVal.x * StatsManager.Instance.dashForce,0);
            
            rb.AddForce(dashDirection, ForceMode2D.Impulse);

            Invoke("EndDash", StatsManager.Instance.dashTime);
        }
    }

    void EndDash()
    {
        rb.constraints &= ~RigidbodyConstraints2D.FreezePositionY;
        isDashing = false;

        Invoke("ResetDash", StatsManager.Instance.dashCooldown);
    }

    void ResetDash()
    {
        canDash = true;
    }

    void Flip()
    {
        facingDirection *= -1;
        transform.localScale = new Vector3 (transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }

    void OnDrawGizmosSelected()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        }
    }
}
