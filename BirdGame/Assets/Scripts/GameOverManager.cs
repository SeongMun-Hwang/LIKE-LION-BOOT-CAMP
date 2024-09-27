using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public TextMeshProUGUI ScoreText;

    private void Start()
    {
        ScoreText.text = PlayerPrefs.GetInt("Score")+"";
    }
    public void PlayAgain()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
