using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelPanel : MonoBehaviour
{
    public int StageIndex;
    public Image StageThumb;
    public TextMeshProUGUI TextTitle;

    public void SetLevelInformation(int stageIndex, Sprite thumbnail, string title)
    {
        StageThumb.sprite = thumbnail;
        TextTitle.text = title;
        StageIndex = stageIndex;
    }
    public void StageStart()
    {
        LevelManager.Instance.StartLevel(StageIndex);
    }
}
