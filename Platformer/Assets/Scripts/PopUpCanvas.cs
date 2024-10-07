using NUnit.Framework;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class PopUpCanvas : MonoBehaviour
{
    [SerializeField]
    private TMP_Text resultTitle;
    [SerializeField]
    private TMP_Text scoreText;
    [SerializeField]
    private GameObject highScore;
    [SerializeField]
    private GameObject highScores;

    private void OnEnable()
    {
        Time.timeScale = 0;
        if (GameManager.Instance.IsCleared)
        {
            resultTitle.text = "Cleared!";
            scoreText.text = GameManager.Instance.TimeLimit.ToString("#.##");
            SaveHighScore();
        }
        else
        {
            resultTitle.text = "Game Over!";
            scoreText.text = "";
        }
    }
    public void AgainPressed()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("SampleScene");
    }
    public void QuitPressed()
    {
        Application.Quit();
    }
    void SaveHighScore()
    {
        float score = GameManager.Instance.TimeLimit;
        float highsore = PlayerPrefs.GetFloat("highscore", 0);
        if(GameManager.Instance.TimeLimit > highsore)
        {
            highScore.SetActive(true);
            PlayerPrefs.SetFloat("highscore",GameManager.Instance.TimeLimit);
        }
        else {
            highScore.SetActive(false);
        }

        string currentScoreString=score.ToString("#.##");
        string savedScoreString = PlayerPrefs.GetString("HighScores", "");

        if (savedScoreString == "")
        {
            PlayerPrefs.SetString("HighScores",currentScoreString);
        }
        else
        {
            string[] scoreArray=savedScoreString.Split(',');
            List<string> scoreList=new List<string>(scoreArray);

            for(int i=0;i<scoreList.Count;i++)
            {
                float savedScore=float.Parse(scoreList[i]);
                if (savedScore < score)
                {
                    scoreList.Insert(i, currentScoreString);
                    break;
                }
            }
            if (scoreArray.Length == scoreList.Count)
            {
                scoreList.Add(currentScoreString);
            }
            if (scoreList.Count > 10)
            {
                scoreList.RemoveAt(10);
            }
            string result = string.Join(",",scoreList);
            Debug.Log(result);
            PlayerPrefs.SetString("HighScores",result);
        }
        PlayerPrefs.Save();
    }
    public void ShowHighScores()
    {
        highScores.SetActive(true);
    }
}
