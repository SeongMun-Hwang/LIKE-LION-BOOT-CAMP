using UnityEngine;

public class Player : MonoBehaviour
{
    public float Gravity = 10f;
    public float Accel = 10f;
    float v = 0;
    void Start()
    {
        v = 0;
    }

    void Update()
    {
        //if (Input.GetButtonDown("Jump"))
        //{

        //}
        //if (Input.GetButtonUp("Jump"))
        //{

        //}
        if (Input.GetButton("Jump"))
        {
            v -= Accel * Time.deltaTime;
        }
        else
        {
            v += Gravity * Time.deltaTime;
        }
    }
    private void FixedUpdate()
    {
        transform.Translate(Vector2.down * v * Time.fixedDeltaTime);
    }
}
