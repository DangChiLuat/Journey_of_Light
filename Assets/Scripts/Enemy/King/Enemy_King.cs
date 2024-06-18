using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class Enemy_King : Enemy
{
    [Header(" UI HP")]
    [SerializeField] public GameObject UIHP;
    #region
    public KingIdleState idleState {  get; private set; }
    public KingMoveState moveState { get; private set; }
    public KingAttackState attackState { get; private set; }
    public KingBattleState battleState { get; private set; }
    public KingTeleportState teleportState { get; private set; }

    public KingAttackTripState attackTripState { get; private set; }

    public KingDeadState deadState { get; private set; }

    #endregion
    protected override void Awake()
    {
        base.Awake();
        idleState = new KingIdleState(this, stateMachine, "Idle", this);
        moveState = new KingMoveState (this,stateMachine,"Move", this);
        attackState = new KingAttackState (this,stateMachine,"Attack", this);
        battleState = new KingBattleState (this,stateMachine,"Battle", this);
        teleportState = new KingTeleportState(this, stateMachine,"TeleportAttack", this);
        attackTripState = new KingAttackTripState(this, stateMachine, "AttackTrip", this);
        deadState = new KingDeadState(this, stateMachine, "Dead", this);
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
           // stateMachine.ChangeState(stunnedState);
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
        stateMachine.ChangeState(deadState);
    }
}
