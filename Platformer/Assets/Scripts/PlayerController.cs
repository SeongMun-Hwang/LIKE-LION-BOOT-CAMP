using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Speed = 5f;
    public float JumpSpeed = 5f;
    public Collider2D BottomCollider;
    public CompositeCollider2D TerrainCollider;

    private Rigidbody2D playerRigidbody;
    private SpriteRenderer playerSpriteRenderer;
    private Animator playerAnimator;
    private bool grounded;
    private float vx; //수평 이동 속도
    private bool isJumped;

    private void Start()
    {
        playerAnimator = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody2D>();
        playerSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        HandleMovement();
        HandleAnimation();
    }

    void HandleMovement()
    {
        vx = Input.GetAxisRaw("Horizontal") * Speed;
        float vy = playerRigidbody.linearVelocity.y;

        if (vx < 0) playerSpriteRenderer.flipX = true;
        else if (vx > 0) playerSpriteRenderer.flipX = false;

        if (Input.GetButtonDown("Jump"))
        {
            if(grounded)
            {
                playerAnimator.SetTrigger("Jump");
                isJumped = true;
            }
            else if (isJumped)
            {
                playerAnimator.SetTrigger("DoubleJump");
                isJumped = false;
            }
                vy= JumpSpeed;
        }

        playerRigidbody.linearVelocity = new Vector2(vx, vy);
        grounded = BottomCollider.IsTouching(TerrainCollider);

        if (grounded) isJumped = false;
    }

    void HandleAnimation()
    {
        if (grounded) //땅에 닿아 있는데
        {
            if (vx == 0) playerAnimator.SetTrigger("Idle"); //x좌표 이동 없으면 Idle
            else playerAnimator.SetTrigger("Run"); //x좌표 이동 중이면 Run
        }
        else //땅에 안 닿아 있는데 
        {
            if (playerRigidbody.linearVelocity.y > 0) playerAnimator.SetTrigger("Jump"); //y벡터가 양수면 점프                        
            else playerAnimator.SetTrigger("Fall"); //y 벡타가 음수면 Fall
        }
    }
}