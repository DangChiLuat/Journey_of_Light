﻿using System.Collections;
using UnityEngine;

    public class NightBone_IdleState : NightBoneGroundedState
    {
        public NightBone_IdleState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animBoolName, Enemy_NightBone _enemy) : base(_enemyBase, _stateMachine, _animBoolName, _enemy)
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