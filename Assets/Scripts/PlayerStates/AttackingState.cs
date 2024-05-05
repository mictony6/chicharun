
public class AttackState : PlayerState
{
    public AttackState(PlayerStateMachine player) : base(player)
    {
    }

    public override void OnEnter()
    {
        player.weaponBehavior.Shoot();
        player.TransitionToPrev();
    }

    public override void OnExit()
    {

    }

    public override void OnUpdate()
    {

    }
}