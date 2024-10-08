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

    [SerializeField]
    private GameObject popupCanvas;

    private bool isCleared;
    public bool IsCleared {  get { return isCleared; } }

    public ObjectPool BulletPool;

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
        Instantiate(LevelManager.Instance.SelectedPrefab);
        LifeDisplayerInstance.SetLives(life);
    }
    
    void Update()
    {
        TimeLimit -= Time.deltaTime;
        TimeLimitText.text = "Time Left : " + (int)TimeLimit;
        if (TimeLimit < 0)
        {
            GameOver();
        }
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
        isCleared=false;
        popupCanvas.SetActive(true);
        Debug.Log("Game Over");
    }
    public void GameClear()
    {
        isCleared = true;
        popupCanvas.SetActive(true);
    }
}
