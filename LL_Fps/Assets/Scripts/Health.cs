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

    void Update()
    {
        healthListenter = GetComponent<IHealthListenter>();
    }
    public void Damage(float damage)
    {
        if (hp > 0 && lastDamageTime + invincibleTime < Time.time)
        {
            hp -= damage;
            if(healthBar!= null)
            {
                healthBar.fillAmount = hp / maxHp;
            }

            lastDamageTime = Time.time;
            if (hp <= 0)
            {
                if (healthListenter != null)
                {
                    healthListenter.OnDie();
                    Debug.Log(gameObject.tag + " : À¸¾Ó Áê±Ý");
                }
            }
            else
            {
                Debug.Log(gameObject.tag + " : ¾î¾ý \nDamaged : " + damage);
            }
        }
    }
    public interface IHealthListenter
    {
        void OnDie();
    }
}