using TMPro;
using UnityEngine;

public class ScoreText : MonoBehaviour
{
    void Start()
    {
    }

    void Update()
    {
        float score = GameManager.Instance.Score;
        GetComponent<TextMeshProUGUI>().text=(int)score+"";
    }
}
