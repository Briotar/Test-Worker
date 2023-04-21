using UnityEngine;
using AxGrid.Base;

public class Mover : MonoBehaviourExt
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _speed = 0.01f;
    [SerializeField] private bool _isNeedToMove = false;

    [OnUpdate]
    private void Move()
    {
        if(_isNeedToMove)
            transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed);

        float diff = (transform.position - _target.position).magnitude;
        if(diff <= 0.01f)
        {
            Debug.Log("Стою в точке!");
        }
    }
}