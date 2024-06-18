using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine 
{
    public PlayerState currentState { get; private set; }
    //  get; private set;lay gia tri cong khai co the doc duoc o ben ngoai nhung can thiet lap o ben trong

    //Initialize trang thai cua nguoi choi
    public void Initialize(PlayerState _startState)
    {
        currentState = _startState;
        currentState.Enter();
    }

    // khoi tao trang thai moi cua nguoi choi
    public void ChangeState(PlayerState _newState)
    {
        currentState.Exit();
        currentState = _newState;
        currentState.Enter();
    }
}
