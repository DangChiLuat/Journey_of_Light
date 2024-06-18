using UnityEngine;

public class PlayerCounterAttackState : PlayerState
{
    private bool canCreateClone;

    public PlayerCounterAttackState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        canCreateClone = true;
        // thoi gian tan cong
        stateTimer = player.counterAttackDuration;
        // tat trang thai tan cong
        player.anim.SetBool("SuccessfulCounterAttack", false);
    }

    public override void Exit()
    {
        base.Exit();


    }

    public override void Update()
    {
        base.Update();

        player.SetZeroVelocity();

        Collider2D[] colliders = Physics2D.OverlapCircleAll(player.attackCheck.position, player.attackCheckRadius);

        foreach (var hit in colliders)
        {
            // trang thai phan cong 
            if (hit.GetComponent<Arrow_Controller>() != null)
            {
                hit.GetComponent<Arrow_Controller>().FlipArrow();
                SuccesfulCounterAttack();
            }

            // neu phat hien co va cham thuc hien tan cong
            if (hit.GetComponent<Enemy>() != null)
            {
                if (hit.GetComponent<Enemy>().CanBeStunned())
                    {
                        SuccesfulCounterAttack();

                        player.skill.parry.UseSkill(); // su dung ki nang hoi mau cua ki nang parry

                    // tao ra ban clone
                        if (canCreateClone)
                        {
                            canCreateClone = false;
                            player.skill.parry.MakeMirageOnParry(hit.transform);
                        }
                    }
            }
        }
        // neu het thoi gian hanh dong hoac het thoi gian cho tra lai trang thai idle
        if (stateTimer < 0 || triggerCalled)
            stateMachine.ChangeState(player.idleState);
    }


    // tao ham hoan thanh combo
    private void SuccesfulCounterAttack()
    {
        stateTimer = 10; // any value bigger than 1
        player.anim.SetBool("SuccessfulCounterAttack", true);
    }
}
