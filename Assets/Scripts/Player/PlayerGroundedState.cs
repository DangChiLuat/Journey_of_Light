using UnityEngine;

public class PlayerGroundedState : PlayerState
{
    public PlayerGroundedState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
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

        if (Input.GetKeyDown(KeyCode.R) && player.skill.blackhole.blackholeUnlocked && player.stats.currentEnergy >= 50)
        {

            if (player.skill.blackhole.cooldownTimer > 0)
            {
                player.fx.CreatePopUpText("Cooldown!");
                return;
            }

            player.stats.EnergyConsumption(50);
            stateMachine.ChangeState(player.blackHole);
        }

        if (Input.GetKeyDown(KeyCode.Mouse1) && HasNoSword() && player.skill.sword.swordUnlocked)
        {
            // Kiểm tra xem có đủ năng lượng hay không
            if (player.stats.currentEnergy >= 20)
            {
                stateMachine.ChangeState(player.aimSowrd);
                player.stats.EnergyConsumption(20);
            }
            else
            {
                player.fx.CreatePopUpText("not enought Enegry");
                return;
            }
        }

        if (Input.GetKeyDown(KeyCode.Q) && player.skill.parry.parryUnlocked)
        {
            if (player.stats.currentEnergy >= 10)
            {
                stateMachine.ChangeState(player.counterAttack);
                player.stats.EnergyConsumption(10);
            } 
            else
            {
                player.fx.CreatePopUpText("not enought Enegry");
                return;
            }
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
            stateMachine.ChangeState(player.primaryAttack);

        if (!player.IsGroundDetected())
            stateMachine.ChangeState(player.airState);

        if (Input.GetKeyDown(KeyCode.Space) && player.IsGroundDetected())
            stateMachine.ChangeState(player.jumpState);
    }

    private bool HasNoSword()
    {
        if (!player.sword)
        {
            return true;
        }

        player.sword.GetComponent<Sword_Skill_Controller>().ReturnSword();
        return false;
    }
}
