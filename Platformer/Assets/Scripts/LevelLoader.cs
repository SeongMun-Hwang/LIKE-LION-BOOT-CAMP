using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    public PlayerController PlayerController;
    public GameObject Cinemachine;

    private void Start()
    {
        GameManager.Instance.playerController = PlayerController;
        GameManager.Instance.Camera = Cinemachine;
    }
}
