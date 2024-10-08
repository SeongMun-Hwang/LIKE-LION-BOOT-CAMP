using UnityEngine;
using System.Collections.Generic;
using System;
using UnityEngine.SceneManagement;

[Serializable]
public class LevelInfo {
    public string LevelName;
    public Sprite LevelThumb;
    public GameObject LevelPrefab;
}

public class LevelManager : MonoBehaviour
{
    public List<LevelInfo> levels;
    private static LevelManager instance;
    public GameObject SelectedPrefab;
    public static LevelManager Instance
    {
        get { return instance; }
        private set
        {
            instance = value;
        }
    }
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void StartLevel(int index)
    {
        SelectedPrefab=levels[index].LevelPrefab;
        SceneManager.LoadScene("SampleScene");
    }
}
