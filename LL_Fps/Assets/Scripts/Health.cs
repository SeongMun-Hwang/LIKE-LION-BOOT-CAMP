using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public float hp = 10;
    public float maxHp = 10;
    IHealthListenter healthListenter;

    public float lastDamageTime;
    public float invincibleTime;

    public Image healthBar;

    public AudioClip dieSound;
    public AudioClip hurtSound;

    void Update()
    {
        healthListenter = GetComponent<IHealthListenter>();
    }
    public void Damage(float damage)
    {
        if (hp > 0 && lastDamageTime + invincibleTime < Time.time)
        {
            hp -= damage;
            if (healthBar != null)
            {
                healthBar.fillAmount = hp / maxHp;
            }

            lastDamageTime = Time.time;
            if (hp <= 0)
            {
                if (healthListenter != null)
                {
                    healthListenter.OnDie();
                    if(dieSound != null) GetComponent<AudioSource>().PlayOneShot(dieSound);
                    Debug.Log(gameObject.tag + " : ���� ���");
                }
            }
            else
            {
                if(hurtSound != null) GetComponent<AudioSource>().PlayOneShot(hurtSound);
                Debug.Log(gameObject.tag + " : ��� \nDamaged : " + damage);
            }
        }
    }
    public interface IHealthListenter
    {
        void OnDie();
    }
}