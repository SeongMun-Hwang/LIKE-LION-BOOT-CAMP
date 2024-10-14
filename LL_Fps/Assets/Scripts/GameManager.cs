using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static private GameManager instance=null;
    public GameObject GameOverCanvas;
    static public GameManager Instance
    {
        get { return instance; }
    }

    public bool isPlaying;
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        isPlaying = true;
    }
    public void GameEnd()
    {
        isPlaying=false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        GameOverCanvas.SetActive(true);
    }
    public void TryAgain()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void Quit()
    {
        Application.Quit();
    }
}
