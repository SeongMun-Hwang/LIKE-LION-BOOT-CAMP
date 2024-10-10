using UnityEngine;

public class WeaponController : MonoBehaviour
{
    Animator animator;
    public Transform firePosition;
    public GameObject linePrefab;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void FireWeapon()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("1911_Idle"))
        {
            animator.SetTrigger("Fire");
            RayCastFire();
        }
    }
    public void ReloadWeapon()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("1911_Idle"))
        {
            animator.SetTrigger("Reload");
        }
    }
    public void RayCastFire()
    {
        Camera cam=Camera.main;
        RaycastHit hit;
        Ray r = cam.ViewportPointToRay(Vector3.one / 2);

        Vector3 hitPosition = r.direction * 200;

        if(Physics.Raycast(r, out hit, 1000)) //¾îµò°¡¿¡ ºÎµóÄ¡¸é True
        {
            hitPosition= hit.point;
        }
        GameObject go = Instantiate(linePrefab);
        Vector3[] pos = new Vector3[] { firePosition.position, hitPosition };
        go.GetComponent<LineRenderer>().SetPositions(pos);
    }
}
