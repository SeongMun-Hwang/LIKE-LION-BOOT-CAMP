using UnityEngine;

public class AttackState : IState
{
    PlayerController player;
    public AttackState(PlayerController player)
    {
        this.player = player;
    }
    public void Enter()
    {
        player.GetComponent<Animator>().SetTrigger("Attack");
    }

    public void Execute()
    {
    }

    public void Exit()
    {
    }
}
