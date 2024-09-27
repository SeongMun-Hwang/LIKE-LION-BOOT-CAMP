using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float Gravity = 10f;
    public float Accel = 10f;
    float v = 0;

    public AudioClip UpSound;
    public AudioClip DownSound;
    void Start()
    {
        v = 0;
        GetComponent<AudioSource>().Play();
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            GetComponent<AudioSource>().PlayOneShot(UpSound);
        }
        if (Input.GetButtonUp("Jump"))
        {
            GetComponent<AudioSource>().PlayOneShot(DownSound);
        }

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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Wall")
        {
            Debug.Log("Ва!!!!");
            int score = (int)GameManager.Instance.Score;
            PlayerPrefs.SetInt("Score", score);

            Destroy(gameObject);
            SceneManager.LoadScene("GameOverScene");
        }
    }
}
