using UnityEngine;

public class FruitController : MonoBehaviour
{
    public float AddTime = 5.0f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager.Instance.AddTime(AddTime);
            GetComponent<Animator>().SetTrigger("Eaten");
            GetComponent<Collider2D>().enabled = false;
        }
    }
    public void DestroyThis()
    {
        Destroy(gameObject);
    }
}
