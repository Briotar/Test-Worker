using UnityEngine;
using AxGrid;
using AxGrid.Model;
using AxGrid.FSM;

[State("EntryState")]
public class EntryState : FSMState
{
    [Enter]
    private void EnterThis()
    {
        Log.Debug($"{Parent.CurrentStateName} ENTER");

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