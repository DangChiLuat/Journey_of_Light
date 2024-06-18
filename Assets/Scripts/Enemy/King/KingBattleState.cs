using System.Collections;
using TMPro;
using UnityEngine;

public class KingBattleState : EnemyState
{
    private Transform player;
    private Enemy_King enemy;
    private int moveDir;
    private bool flipOne;

    public KingBattleState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animBoolName,Enemy_King _enemy) : base(_enemyBase, _stateMachine, _animBoolName)
    {
        this.enemy = _enemy;
    }

    public override void Enter()
    {
        base.Enter();
        enemy.UIHP.SetActive(true);
        player = PlayerManager.instance.player.transform;
        if (player.GetComponent<PlayerStats>().isDead)
            stateMachine.ChangeState(enemy.moveState);

        flipOne = false;

    }

    public override void Update()
    {
        base.Update();
        enemy.anim.SetFloat("xVelocity", enemy.rb.velocity.x);
        if (enemy.IsPlayerDetected())
        {
            stateTimer = enemy.battleTime;

            if (enemy.IsPlayerDetected().distance < enemy.attackDistance)
            {
                if (CanAttack())
                {
                    TriggerAttackOrTeleport();
                }
            }
        }
        else
        {
            if (flipOne == false)
            {
                flipOne = true;
                enemy.Flip();
            }


            if (stateTimer < 0 || Vector2.Distance(player.transform.position, enemy.transform.position) > 7)
                stateMachine.ChangeState(enemy.idleState);
        }

        float distanceToPlayerX = Mathf.Abs(player.transform.position.x - enemy.transform.position.x);
        if(distanceToPlayerX< 2f)
        {
            return;
        }

        if (player.position.x > enemy.transform.position.x)
            moveDir = 1;
        else if (player.position.x < enemy.transform.position.x)
            moveDir = -1;

        enemy.SetVelocity(enemy.moveSpeed * moveDir, rb.velocity.y);
    }

    public override void Exit()
    {
        base.Exit();
    }

    private bool CanAttack()
    {
        if (Time.time >= enemy.lastTimeAttacked + enemy.attackCooldown)
        {
            enemy.attackCooldown = Random.Range(enemy.minAttackCooldown, enemy.maxAttackCooldown);
            enemy.lastTimeAttacked = Time.time;
            return true;
        }

        return false;
    }

    public void TriggerAttackOrTeleport()
    {
        if (Random.value < .20f && Vector2.Distance(player.transform.position, enemy.transform.position) < 3f)
        {
            AudioManager.instance.PlaySFX(50, enemy.transform);
            stateMachine.ChangeState(enemy.teleportState);
        }
        else
        {
            stateMachine.ChangeState(enemy.attackState);
            AudioManager.instance.PlaySFX(51, enemy.transform);
        }
    }
}