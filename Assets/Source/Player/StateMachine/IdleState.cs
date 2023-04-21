using UnityEngine;
using AxGrid;
using AxGrid.Model;
using AxGrid.FSM;

[State("IdleState")]
public class IdleState : FSMState
{
    [Enter]
    private void EnterThis()
    {
        Log.Debug($"{Parent.CurrentStateName} ENTER");
        Log.Debug("start idle anim");

        Camera.main.backgroundColor = Color.gray;
    }

    [Bind("NewTarget")]
    private void StartRun()
    {
        Parent.Change("RunState");
    }

    [Exit]
    private void ExitThis()
    {
        Log.Debug($"{Parent.CurrentStateName} EXIT");
    }
}