using UnityEngine;

public class Enemy_NightBone : Enemy
{
    [SerializeField] private GameObject expPrefabs;
    #region

    public NightBone_IdleState idleState { get; private set; }
    public NightBone_MoveState moveState { get; private set; }

    public NightBoneAttackState attackState { get; private set; }
    public NightBoneBattleState battleState { get; private set; }
    public NightBoneStunedState nightBoneStuned { get; private set; }

    public NightBoneDeadState deadState { get; private set; }

    #endregion

    protected override void Awake()
    {
        base.Awake();

        idleState = new NightBone_IdleState(this, stateMachine, "Idle", this);
        moveState = new NightBone_MoveState(this, stateMachine, "Move", this);
        attackState = new NightBoneAttackState(this, stateMachine, "Attack", this);
        battleState = new NightBoneBattleState(this, stateMachine, "Battle", this);
        nightBoneStuned = new NightBoneStunedState(this, stateMachine, "Stunned", this);
        deadState = new NightBoneDeadState(this, stateMachine,"Dead", this);
    }

    protected override void Start()
    {
        base.Start();
        // khoi tao trang thai ban dau
        stateMachine.Initialize(idleState);
    }
    public override bool CanBeStunned()
    {
        if (base.CanBeStunned())
        {
            stateMachine.ChangeState(nightBoneStuned);
            return true;
        }

        return false;
    }

    protected override void Update()
    {
        base.Update();
    }

    public override void AnimationSpecialAttackTrigger()
    {
        GameObject newExp = Instantiate(expPrefabs, attackCheck.position, Quaternion.identity);
        newExp.GetComponent<NightBornEXPController>().setUpEXP(stats, attackCheckRadius + .5f);
        AudioManager.instance.PlaySFX(43, null);
    }
    public override void Die()
    {
        base.Die();
           stateMachine.ChangeState(deadState);
    }
}