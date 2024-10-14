using UnityEngine;

public class LookCamera : MonoBehaviour
{
    private void Update()
    {
        transform.LookAt(transform.position + Camera.main.transform.forward);
    }
}
