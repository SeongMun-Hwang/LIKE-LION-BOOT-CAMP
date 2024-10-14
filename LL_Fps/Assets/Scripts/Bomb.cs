using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float time;
    public float damage;
    private void Update()
    {
        time-= Time.deltaTime;

        if(time < 0)
        {
            GetComponent<Animator>().SetTrigger("Explode");
            Destroy(gameObject, 2);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            other.GetComponent<Health>().Damage(damage);
        }
    }
}
