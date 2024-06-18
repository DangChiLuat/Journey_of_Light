using System.Collections;
using UnityEngine;

public class HashashinIdleState : HashashinGroundState
{
    public HashashinIdleState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animBoolName, EnemyHashashin _enemy) : base(_enemyBase, _stateMachine, _animBoolName, _enemy)
    {
    }
    public override void Enter()
    {
        base.Enter();

        stateTimer = enemy.idleTime;

    }

    public override void Exit()
    {
        base.Exit();

        AudioManager.instance.PlaySFX(14, enemy.transform);
    }

    public override void Update()
    {
        base.Update();

        if (stateTimer < 0)
            stateMachine.ChangeState(enemy.moveState);

    }
}