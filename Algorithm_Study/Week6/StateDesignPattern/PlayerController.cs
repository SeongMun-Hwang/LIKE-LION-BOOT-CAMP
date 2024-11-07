using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public StateMachine stateMachine;
    private void Awake()
    {
        stateMachine = new StateMachine(this);
    }
    void Start()
    {
        stateMachine.Initialize(stateMachine.idleState);
    }
    void Update()
    {
        stateMachine.Execute();
    }
    public void OnIdle()
    {
        stateMachine.TransitionTo(stateMachine.idleState);
    }
    public void OnAttack()
    {
        stateMachine.TransitionTo(stateMachine.attackState);
    }
    public void OnSpin()
    {
        stateMachine.TransitionTo(stateMachine.spinState);
    }
    public void OnDeath()
    {
        stateMachine.TransitionTo(stateMachine.deathState);
    }
    public void OnRun()
    {
        stateMachine.TransitionTo(stateMachine.runState);
    }
}
