using TMPro;
using UnityEngine;
using UnityEngine.VFX;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject prefab;
    public float SpawnTerm = 4f;

    float SpawnTimer;
    private float score;
    
    public float Score { get { return score; } }

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        SpawnTimer = 0;
        score = 0;
    }

    void Update()
    {
        SpawnTimer += Time.deltaTime;
        score+= Time.deltaTime;

        if (SpawnTimer > SpawnTerm)
        {
            SpawnTimer-=SpawnTerm;

            GameObject obj = Instantiate(prefab);
            obj.transform.position = new Vector2(10, Random.Range(-2f,2f));
        }
    }
}
