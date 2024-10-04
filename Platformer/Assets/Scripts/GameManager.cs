using TMPro;
using Unity.Cinemachine;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    public LifeDisplayer LifeDisplayerInstance;
    int life;

    public PlayerController playerController;

    public GameObject Camera;
    public GameObject[] Lives;
    public static GameManager Instance
    {
        get { return instance; }
    }

    public float TimeLimit = 30;
    public TextMeshProUGUI TimeLimitText;

    private void Awake()
    {
        instance = this;
        life = 3;
    }

    void Update()
    {
        TimeLimit -= Time.deltaTime;
        TimeLimitText.text = "Time Left : " + (int)TimeLimit;
    }
    public void AddTime(float time)
    {
        TimeLimit+= time;
    }
    public void Die()
    {
        Camera.SetActive(false);
        life--;
        LifeDisplayerInstance.SetLives(life);

        Invoke("Restart", 2);
        Debug.Log("dead");
    }
    void Restart()
    {
        if (life > 0)
        {
            Camera.SetActive(true);
            playerController.Restart();
        }
        else
        {
            GameOver();
        }
    }
    void GameOver()
    {
        Debug.Log("Game Over");
    }
}
