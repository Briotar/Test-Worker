using UnityEngine;
using AxGrid;
using AxGrid.Base;
using AxGrid.FSM;
using AxGrid.Model;

[RequireComponent(typeof(Player))]
public class StateMachine : MonoBehaviourExtBind
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _speed = 0.0015f;

    private Player _player;

    [OnAwake]
    private void AwakeThis()
    {
        Log.Debug("Main Awake");
    }

    [OnStart]
    private void StartThis()
    {
        _player = GetComponent<Player>();

        Log.Debug("Main Start");
        Settings.Fsm = new FSM();
        Settings.Fsm.Add(new IdleState());
        Settings.Fsm.Add(new RunState());
        Settings.Fsm.Add(new StayState());

        Settings.Fsm.Start("IdleState");
    }

    [OnUpdate]
    private void UpdateThis()
    {
        Settings.Fsm.Update(Time.deltaTime);

        if(Settings.Fsm.CurrentStateName == "RunState")
            Move();
    }

    [Bind("NewTarget")]
    private void SetNewTarget(Transform newTarget)
    {
        _target = newTarget;
    }

    private void Move()
    {
        _player.transform.position = Vector3.MoveTowards(_player.transform.position, _target.position, _speed);

        float diff = (_player.transform.position - _target.position).magnitude;
        if (diff <= 0.01f)
        {
            Settings.Invoke("Stop");
        }
    }
}