using UnityEngine;
using AxGrid;
using AxGrid.FSM;
using AxGrid.Model;

[State("RunState")]
public class RunState : FSMState
{
    [Enter]
    private void EnterThis()
    {
        Log.Debug("start run anim");

        Camera.main.backgroundColor = new Color(0.1f, 0.2f, 0.3f);
    }

    [Bind("Stop")]
    private void NextState()
    {
        Parent.Change("StayState");
    }

    [Exit]
    private void ExitThis()
    {
        Log.Debug($"{Parent.CurrentStateName} EXIT");
    }
}