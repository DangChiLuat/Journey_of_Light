using UnityEngine;

public class HashashinAttackState : EnemyState
{
    private EnemyHashashin enemy;

    public int comboCounter;

    private float lastTimeAttacked;
    private float comboWindow = 2;
    public HashashinAttackState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animBoolName, EnemyHashashin _enemy) : base(_enemyBase, _stateMachine, _animBoolName)
    {
        this.enemy = _enemy;
    }


    public override void Enter()
    {
        base.Enter();

        if (comboCounter == 0)
        {
            AudioManager.instance.PlaySFX(44, enemy.transform);
        }
       else if(comboCounter == 1)
        {
            AudioManager.instance.PlaySFX(45,enemy.transform);
        }else if(comboCounter == 2)
        {
            AudioManager.instance.PlaySFX(46,enemy.transform);
        }



        if (comboCounter > 2 || Time.time >= lastTimeAttacked + comboWindow)
            comboCounter = 0;

        Debug.Log(comboCounter);
        enemy.anim.SetInteger("ComboCounter", comboCounter);
    }

    public override void Exit()
    {
        base.Exit();
        comboCounter++;
        lastTimeAttacked = Time.time;
    }
    public override void Update()
    {
        base.Update();
        if (triggerCalled)
        {
            stateMachine.ChangeState(enemy.idleState);
        }
    }
}