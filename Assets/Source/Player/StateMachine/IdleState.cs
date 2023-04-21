using UnityEngine;
using AxGrid;
using AxGrid.FSM;

[State("IdleState")]
public class IdleState : FSMState
{
    [Enter]
    private void EnterThis()
    {
        Log.Debug($"{Parent.CurrentStateName} ENTER");
        Log.Debug("start idle anim");
    }

    [Exit]
    private void ExitThis()
    {
        Log.Debug($"{Parent.CurrentStateName} EXIT");
    }
}