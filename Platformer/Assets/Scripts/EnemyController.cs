using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float Speed;
    public CompositeCollider2D TerrainCollider;
    public Collider2D FrontBottomCollider;
    public Collider2D FrontCollider;

    public int Hp = 3;
    Vector2 vx;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        vx = Vector2.right * Speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (FrontCollider.IsTouching(TerrainCollider) || !FrontBottomCollider.IsTouching(TerrainCollider))
        {
            vx = -vx;
            transform.localScale = new Vector2(-transform.localScale.x, 1);
        }
    }
    private void FixedUpdate()
    {
        transform.Translate(vx * Time.fixedDeltaTime);
    }
    public void Hit(int damage)
    {
        Hp -= damage;
        if (Hp < 0)
        {
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            GetComponent<Rigidbody2D>().angularVelocity = 720;
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 10), ForceMode2D.Impulse);
            GetComponent<BoxCollider2D>().enabled = false;

            Invoke("DestroyThis", 2f);
        }
    }
    void DestroyThis()
    {
        Destroy(gameObject);
    }
}
