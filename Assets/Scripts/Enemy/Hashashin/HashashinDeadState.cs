﻿using System.Collections;
using UnityEngine;

public class HashashinDeadState : EnemyState
{
    private EnemyHashashin enemy;

    public HashashinDeadState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animBoolName, EnemyHashashin _enemy) : base(_enemyBase, _stateMachine, _animBoolName)
    {
        this.enemy = _enemy;
    }
    public override void Enter()
    {
        base.Enter();
    }

    public override void Update()
    {
        base.Update();
        if (stateTimer > 0)
        {
         //   rb.velocity = new Vector2(0, 10);
        }
    }
}