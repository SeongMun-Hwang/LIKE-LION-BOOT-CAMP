using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class WeaponController : MonoBehaviour
{
    Animator animator;
    public Transform firePosition;
    public GameObject linePrefab;
    public GameObject particlePrefab;

    public int currentBullet = 8;
    public int totalBullet = 12;
    public int maxBullet = 12;
    public TextMeshProUGUI bulletText;

    public float damage;
    public AudioClip gunSound;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        bulletText.text = currentBullet + "/" + totalBullet;
    }
    public void FireWeapon()
    {
        if (currentBullet > 0)
        {
            if (animator != null)
            {
                if (animator.GetCurrentAnimatorStateInfo(0).IsName("1911_Idle"))
                {
                    animator.SetTrigger("Fire");
                    currentBullet--;
                    Fire();
                }
            }
            else
            {
                currentBullet--;
                Fire();
            }
        }       
    }
    protected virtual void Fire()
    {
        RayCastFire();
    }
    public void ReloadWeapon()
    {
        if (totalBullet > 0)
        {
            if (animator != null)
            {
                if (animator.GetCurrentAnimatorStateInfo(0).IsName("1911_Idle"))
                {
                    animator.SetTrigger("Reload");
                    Reload();
                }
            }
            else
            {
                Reload();
            }
        }
    }
    public void Reload()
    {
        if (totalBullet >= maxBullet - currentBullet)
        {
            totalBullet -= maxBullet - currentBullet;
            currentBullet = maxBullet;
        }
        else
        {
            currentBullet += totalBullet;
            totalBullet = 0;
        }
    }
    public void RayCastFire()
    {
        GetComponent<AudioSource>().PlayOneShot(gunSound);
        Camera cam = Camera.main;
        RaycastHit hit;
        Ray r = cam.ViewportPointToRay(Vector3.one / 2);

        Vector3 hitPosition = r.direction * 200;

        if (Physics.Raycast(r, out hit, 1000)) //¾îµò°¡¿¡ ºÎµóÄ¡¸é True
        {
            hitPosition = hit.point;
            //GameObject particle = Instantiate(particlePrefab);
            //particle.transform.position = hitPosition;
            //particle.transform.forward = hit.normal;

            if (hit.collider.CompareTag("Enemy"))
            {
                hit.collider.GetComponent<Health>().Damage(damage);
            }
        }
        GameObject go = Instantiate(linePrefab);
        Vector3[] pos = new Vector3[] { firePosition.position, hitPosition };
        go.GetComponent<LineRenderer>().SetPositions(pos);

        StartCoroutine(DestroyLine(go));
    }

    IEnumerator DestroyLine(GameObject obj)
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(obj);
    }
}
