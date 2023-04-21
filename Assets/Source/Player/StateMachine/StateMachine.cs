using UnityEngine;
using AxGrid;
using AxGrid.Base;
using AxGrid.FSM;
using AxGrid.Model;
using AxGrid.Path;

[RequireComponent(typeof(Player))]
public class StateMachine : MonoBehaviourExtBind
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _speed = 0.0015f;
    [SerializeField] private float _timeAnim = 10f;

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
    }

    [Bind("NewTarget")]
    private void SetNewTarget(Transform newTarget)
    {
        _target = newTarget;

        Path = new CPath();
        Move();
    }

    private void Move()
    {
        Path.EasingLinear(_timeAnim, _player.transform.position.x, _target.transform.position.x, value =>
        {
            _player.transform.position = new Vector3(value, _player.transform.position.y, _player.transform.position.z);
        })
        .EasingLinear(_timeAnim, _player.transform.position.y, _target.transform.position.y, value =>
        {
            _player.transform.position = new Vector3(_player.transform.position.x, value, _player.transform.position.z);
        })
        .Action(() => { Settings.Invoke("Stop"); });
    }
}