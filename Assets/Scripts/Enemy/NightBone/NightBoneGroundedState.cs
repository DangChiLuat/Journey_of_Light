using System.Collections;
using UnityEngine;

    public class NightBoneGroundedState : EnemyState
    {
        protected Enemy_NightBone enemy;
        protected Transform player;
        public NightBoneGroundedState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animBoolName, Enemy_NightBone _enemy) : base(_enemyBase, _stateMachine, _animBoolName)
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

            if (enemy.IsPlayerDetected() || Vector2.Distance(enemy.transform.position, player.transform.position) < enemy.agroDistance)
            {
                stateMachine.ChangeState(enemy.battleState);
            }
        }
    }