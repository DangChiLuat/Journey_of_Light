using System.Collections;
using UnityEngine;

public class HashashinGroundState : EnemyState
{

    protected EnemyHashashin enemy;
    protected Transform player;
    public HashashinGroundState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animBoolName, EnemyHashashin _enemy) : base(_enemyBase, _stateMachine, _animBoolName)
    {
        this.enemy = _enemy;
    }

    public override void Enter()
    {
        base.Enter();

        player = PlayerManager.instance.player.transform;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        if(Input.GetKeyUp(KeyCode.Y))
        {
            stateMachine.ChangeState(enemy.attackState);
        }

        if (enemy.IsPlayerDetected() || Vector2.Distance(enemy.transform.position, player.transform.position) < enemy.agroDistance)
        {
            stateMachine.ChangeState(enemy.battleState);
        }
    }
}