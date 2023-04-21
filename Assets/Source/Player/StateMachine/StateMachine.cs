using UnityEngine;
using AxGrid;
using AxGrid.Base;
using AxGrid.FSM;
using AxGrid.Model;

public class StateMachine : MonoBehaviourExtBind
{
    [OnAwake]
    private void AwakeThis()
    {
        Log.Debug("Main Awake");
    }

    [OnStart]
    private void StartThis()
    {
        Log.Debug("Main Start");
        Settings.Fsm = new FSM();
        Settings.Fsm.Add(new IdleState());

        Settings.Fsm.Start("IdleState");
    }

    [OnUpdate]
    private void UpdateThis()
    {
        Settings.Fsm.Update(Time.deltaTime);
    }
}