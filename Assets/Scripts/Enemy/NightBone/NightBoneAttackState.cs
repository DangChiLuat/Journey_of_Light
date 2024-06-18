using System.Collections;
using UnityEngine;

    public class NightBoneAttackState : EnemyState
    {
        private Enemy_NightBone enemy;
        public NightBoneAttackState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animBoolName, Enemy_NightBone _enemy) : base(_enemyBase, _stateMachine, _animBoolName)
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