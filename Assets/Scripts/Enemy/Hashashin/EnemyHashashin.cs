
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHashashin : Enemy
{
    #region Stats
    public HashashinIdleState idleState {  get; private set; }
    public HashashinMoveState moveState { get; private set; }
    public HashashinDeadState deadState { get; private set; }
    public HashashinAttackState attackState { get; private set; }

    public HashashinBattleState battleState { get; private set; }
    public HashashinAirState airState { get; private set; }

    #endregion


    protected override void Awake()
    {
        base.Awake();
        idleState = new HashashinIdleState(this, stateMachine, "Idle", this);
        moveState = new HashashinMoveState(this, stateMachine, "Move", this);
        attackState = new HashashinAttackState(this, stateMachine, "Attack", this);
        deadState = new HashashinDeadState(this, stateMachine, "Dead", this);
        battleState = new HashashinBattleState(this, stateMachine, "Battle", this);
        airState = new HashashinAirState(this, stateMachine, "Air", this);
    }


    protected override void Start()
    {
        base.Start();
        stateMachine.Initialize(idleState);
    }


    public override bool CanBeStunned()
    {
        if (base.CanBeStunned())
        {
          //  stateMachine.ChangeState(stunnedState);
            return true;
        }

        return false;
    }

    protected override void Update()
    {
        base.Update();
    }
    public override void Die()
    {
        base.Die();
        AudioManager.instance.PlaySFX(48, null);
        stateMachine.ChangeState(deadState);
    }
}
