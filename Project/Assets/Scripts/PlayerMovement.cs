using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; 
    public float jumpForce = 10f; 

    public float fallGravityMultiplier = 2f; 
    public Transform groundCheck;
    public LayerMask groundLayer;
    private bool isGrounded;
    private float groundCheckRadius = 0.2f;

    private Rigidbody2D rb;
    public Animator animator;
    public GameObject playerSprite;

    private float moveInput;
    private AllSFX allSFX;

    void Start()
    {
        allSFX = GetComponent<AllSFX>();
        rb = GetComponent<Rigidbody2D>();
        animator = playerSprite.GetComponent<Animator>();
    }

    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        moveInput = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);

        if (moveInput > 0)  transform.localScale = new Vector3(1, 1, 1);
        else if (moveInput < 0)  transform.localScale = new Vector3(-1, 1, 1);

        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            allSFX.PlayJumpSound();
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
        if (!isGrounded && rb.linearVelocity.y < 0)  rb.gravityScale = 3f * fallGravityMultiplier; 
        else rb.gravityScale = 3f;

        UpdateAnimations();
    }
    void UpdateAnimations()
    {
        animator.SetFloat("Speed", Mathf.Abs(moveInput));
        animator.SetBool("IsGrounded", isGrounded);

        if (!isGrounded && rb.linearVelocity.y > 0)
        {
            animator.SetBool("IsJumping", true);
            animator.SetBool("IsFalling", false);
        }
        else if (!isGrounded && rb.linearVelocity.y < 0)
        {
            animator.SetBool("IsFalling", true);
            animator.SetBool("IsJumping", false);
        }
        else
        {
            animator.SetBool("IsJumping", false); 
            animator.SetBool("IsFalling", false);
        }
    }
}
