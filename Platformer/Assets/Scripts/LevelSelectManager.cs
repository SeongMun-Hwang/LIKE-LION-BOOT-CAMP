using UnityEngine;

public class LevelSelectManager : MonoBehaviour
{
    public GameObject PanelPrefab;
    public GameObject ScrollViewContent;
 
    void Start()
    {
        for(int i = 0; i < LevelManager.Instance.levels.Count; i++)
        {
            LevelInfo info = LevelManager.Instance.levels[i];
            GameObject go = Instantiate(PanelPrefab, ScrollViewContent.transform);
            go.GetComponent<LevelPanel>().SetLevelInformation(i, info.LevelThumb, info.LevelName);
        }
    }
}
