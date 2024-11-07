using UnityEngine;

public class StateMachine
{
    public IState CurrentState { get; private set; }
    PlayerController player;

    public IdleState idleState;
    public SpinState spinState;
    public AttackState attackState;
    public RunState runState;
    public DeathState deathState;

    public StateMachine(PlayerController player)
    {
        this.player = player;
        idleState = new IdleState(player);
        runState = new RunState(player);
        deathState = new DeathState(player);
        spinState = new SpinState(player);
        attackState = new AttackState(player);
    }
    public void Initialize(IState state)
    {
        CurrentState = state;
        state.Enter();
    }
    public void TransitionTo(IState nextState)
    {
        CurrentState.Exit();
        CurrentState= nextState;
        CurrentState.Enter();
    }
    public void Execute()
    {
        CurrentState.Execute();
    }
}
