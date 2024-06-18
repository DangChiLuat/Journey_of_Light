using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDashState : PlayerState
{


    public PlayerDashState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        // CloneOnDash clone 1 ban sao khi bat dau vao trang thai
        player.skill.dash.CloneOnDash();
        stateTimer = player.dashDuration;

        // MakeInvincible trang thai bat tu
        player.stats.MakeInvincible(true);

    }

    public override void Exit()
    {
        base.Exit();

        // CloneOnArrival clone 1 ban sao o diem cuoi
        player.skill.dash.CloneOnArrival();
        player.SetVelocity(0, rb.velocity.y);

        player.stats.MakeInvincible(false);
    }






    public override void Update()
    {
        base.Update();
        

        if (!player.IsGroundDetected() && player.IsWallDetected())
            stateMachine.ChangeState(player.wallSlide);

        player.SetVelocity(player.dashSpeed * player.dashDir, 0);

        if (stateTimer < 0)
            stateMachine.ChangeState(player.idleState);

        player.fx.CreateAfterImage();
    }
}
