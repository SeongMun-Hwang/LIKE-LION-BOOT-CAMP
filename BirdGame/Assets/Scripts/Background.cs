using UnityEngine;

public class Background : MonoBehaviour
{
    public float width;
    public float speed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left*Time.deltaTime * speed);

        if (transform.position.x < -width)
        {
            transform.Translate(new Vector2(width*2, 0));
        }
    }
}
