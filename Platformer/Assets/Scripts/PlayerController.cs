using NUnit.Framework;
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
    private float vx;

    Vector2 originalPostion;
    enum State
    {
        Playing,
        Dead,
    }
    State state;

    private void Start()
    {
        playerAnimator = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody2D>();
        playerSpriteRenderer = GetComponent<SpriteRenderer>();
        originalPostion = transform.position;
        state = State.Playing;
    }

    void Update()
    {
        if (state == State.Dead) return;

        HandleMovement();
        HandleAnimation();
        if (Input.GetButtonDown("Fire1"))
        {
            Vector2 bulletV = new Vector2(10, 0);
            if (GetComponent<SpriteRenderer>().flipX)
            {
                bulletV.x = -bulletV.x;
            }
            GameObject bullet = GameManager.Instance.BulletPool.GetObject();
            bullet.transform.position = transform.position;
            bullet.GetComponent<Bullet>().Velocity = bulletV;
        }
    }

    void HandleMovement()
    {
        vx = Input.GetAxisRaw("Horizontal") * Speed;
        float vy = playerRigidbody.linearVelocity.y;

        if (vx < 0) playerSpriteRenderer.flipX = true;
        else if (vx > 0) playerSpriteRenderer.flipX = false;

        if (Input.GetButtonDown("Jump") && grounded)
        {
            vy = JumpSpeed;
            playerAnimator.SetTrigger("Jump");
        }

        playerRigidbody.linearVelocity = new Vector2(vx, vy);
        grounded = BottomCollider.IsTouching(TerrainCollider);
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
            if (playerRigidbody.linearVelocity.y > 0) playerAnimator.SetTrigger("Jump"); //y벡터가 양수면 Jump
            else playerAnimator.SetTrigger("Fall"); //y 벡타가 음수면 Fall
        }
    }

    public void Restart()
    {
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        GetComponent<Rigidbody2D>().angularVelocity = 0;
        GetComponent<BoxCollider2D>().enabled = true;
        transform.eulerAngles = Vector2.zero;

        transform.position = originalPostion;
        GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
        state = State.Playing;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Die();
        }
    }
    void Die()
    {
        state = State.Dead;
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;

        int x = 0;
        if (playerSpriteRenderer.flipX) x = -1;
        else x = 1;

        GetComponent<Rigidbody2D>().angularVelocity = 720*x;
        GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 10), ForceMode2D.Impulse);
        GetComponent<BoxCollider2D>().enabled = false;

        GameManager.Instance.Die();
    }
}