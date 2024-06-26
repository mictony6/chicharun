public interface IState
{
    void OnEnter();
    void OnExit();
    void OnUpdate();
}

public abstract class PlayerState : IState
{
    public PlayerStateMachine player;

    public PlayerState(PlayerStateMachine player)
    {
        this.player = player;
    }
    public abstract void OnEnter();
    public abstract void OnExit();
    public abstract void OnUpdate();



}

public abstract class EnemyState : IState
{
    public EnemyStateMachine enemy;

    public EnemyState(EnemyStateMachine enemy)
    {
        this.enemy = enemy;
    }
    public abstract void OnEnter();
    public abstract void OnExit();
    public abstract void OnUpdate();

}

