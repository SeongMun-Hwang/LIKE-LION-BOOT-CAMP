using UnityEngine;

public class DeathState : IState
{
    PlayerController player;
    public DeathState(PlayerController player)
    {
        this.player = player;
    }
    public void Enter()
    {
        player.GetComponent<Animator>().SetTrigger("Death");
    }

    public void Execute()
    {
    }

    public void Exit()
    {
    }
}