using TMPro;
using UnityEngine;

public class HighScore : MonoBehaviour
{
    public TMP_Text HighScoreText;

    private void OnEnable()
    {
        string[] scores=PlayerPrefs.GetString("HighScores", "").Split(',');
        Debug.Log("Saved High Scores: " + scores);  // HighScores °ª È®ÀÎ
        string result = "";
        for(int i = 0; i < scores.Length; i++)
        {
            result += (i + 1) + ". " + scores[i] + "\n";
        }
        HighScoreText.text = result;
    }
    public void CloseHighScores()
    {
        gameObject.SetActive(false);
    }
}
