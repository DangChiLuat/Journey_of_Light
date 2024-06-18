using UnityEngine;

public class KingTeleportState : EnemyState
{
    private Transform player;
    private Enemy_King enemy;
    private Vector3 targetPosition;
    private int moveDir;
    public KingTeleportState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animBoolName, Enemy_King _enemy) : base(_enemyBase, _stateMachine, _animBoolName)
    {
        this.enemy = _enemy;
    }

    public override void Enter()
    {
        base.Enter();
        player = PlayerManager.instance.player.transform;
        enemy.stats.MakeInvincible(true);
        enemy.UIHP.SetActive(false);
        enemy.lastTimeAttacked = Time.time;

        if (player.position.x > enemy.transform.position.x)
        {
            moveDir = 1;
            Vector3 vector3 = enemy.transform.position + new Vector3(3f * moveDir, 0, 0);
            targetPosition = vector3;
            // Move the enemy
            enemy.transform.position = targetPosition;
        }
        else if (player.position.x < enemy.transform.position.x)
        {
            moveDir = -1;
            targetPosition = enemy.transform.position + new Vector3(3f * moveDir, 0, 0);
            // Move the enemy
            enemy.transform.position = targetPosition;
        }
    } 
    public override void Update()
    {
        base.Update();
        enemy.SetZeroVelocity();
        if (triggerCalled)
            stateMachine.ChangeState(enemy.attackTripState);
    }

    public override void Exit()
    {
        base.Exit();
        enemy.stats.MakeInvincible(false);
    }

}