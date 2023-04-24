using UnityEngine;
using AxGrid;
using AxGrid.Base;
using AxGrid.FSM;
using AxGrid.Model;
using AxGrid.Path;

[RequireComponent(typeof(Player))]
public class StateMachine : MonoBehaviourExtBind
{
    [SerializeField] private float _timeAnim = 10f;

    private Transform _target;
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
        Settings.Fsm.Add(new EntryState());
        Settings.Fsm.Add(new RunState());
        Settings.Fsm.Add(new StayState());

        Settings.Fsm.Start("EntryState");
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
        Vector2 startPostion = _player.transform.position;

        Path.EasingLinear(_timeAnim, 0, 1, (f) =>
        {
            _player.transform.position = Vector2.Lerp(startPostion, _target.position, f);
        })
        .Action(() => { Settings.Invoke("Stop"); });
    }
}