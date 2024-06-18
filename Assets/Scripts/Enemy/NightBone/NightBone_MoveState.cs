using System.Collections;
using UnityEngine;

    public class NightBone_MoveState : NightBoneGroundedState
    {
        public NightBone_MoveState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animBoolName, Enemy_NightBone _enemy) : base(_enemyBase, _stateMachine, _animBoolName, _enemy)
        {
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

            enemy.SetVelocity(enemy.moveSpeed * enemy.facingDir, rb.velocity.y);

            if (enemy.IsWallDetected() || !enemy.IsGroundDetected())
            {
                enemy.Flip();
                stateMachine.ChangeState(enemy.idleState);
            }

        }
    }