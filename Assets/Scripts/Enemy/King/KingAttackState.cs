using System.Collections;
using UnityEngine;

    public class KingAttackState :EnemyState
    {
    private Enemy_King enemy;

    public KingAttackState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animBoolName,Enemy_King _enemy) : base(_enemyBase, _stateMachine, _animBoolName)
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

        enemy.lastTimeAttacked = Time.time;
    }

    public override void Update()
    {
        base.Update();

        enemy.SetZeroVelocity();



        if (triggerCalled)
            stateMachine.ChangeState(enemy.battleState);
    }

}