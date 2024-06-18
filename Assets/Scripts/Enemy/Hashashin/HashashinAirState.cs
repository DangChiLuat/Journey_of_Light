public class HashashinAirState : EnemyState
{
    private EnemyHashashin enemy;
    public HashashinAirState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animBoolName, EnemyHashashin _enemy) : base(_enemyBase, _stateMachine, _animBoolName)
    {
        this.enemy = _enemy;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        if (triggerCalled)
        {
            enemy.stateMachine.ChangeState(enemy.idleState);
        }
    }


}