using UnityEngine;

public class GrenadeController : WeaponController
{
    public GameObject grenadePrefab;
    public float grenadeAngle = 30;
    public float grenadeForce = 10;
    public float grenadeTime = 5;

    protected override void Fire()
    {
        GrenadeFire();
    }
    void GrenadeFire()
    {
        Camera cam = Camera.main;

        Vector3 forward=cam.transform.forward;
        Vector3 up =cam.transform.up;

        Vector3 direction= forward+up*Mathf.Tan(grenadeAngle*Mathf.Deg2Rad);

        direction.Normalize();
        direction *= grenadeForce;

        GameObject go=Instantiate(grenadePrefab);
        go.transform.position = firePosition.position;
        go.GetComponent<Rigidbody>().AddForce(direction, ForceMode.Impulse);
        go.GetComponent<Bomb>().time = grenadeTime;
    }
}
