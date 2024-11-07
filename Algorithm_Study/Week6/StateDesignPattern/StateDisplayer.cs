using TMPro;
using UnityEngine;

public class StateDisplayer : MonoBehaviour
{
    public TextMeshPro stateLabel;
    PlayerController playerController;

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
    }

    private void OnEnable() //�̺�Ʈ ����
    {
        playerController.stateMachine.stateChanged += OnStateChanged;
    }
    private void OnDisable() //�̺�Ʈ ����
    {
        playerController.stateMachine.stateChanged -= OnStateChanged;
    }
    void OnStateChanged(IState state)
    {
        stateLabel.text=state.GetType().Name;
    }
}
