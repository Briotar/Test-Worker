using UnityEngine;
using AxGrid;
using AxGrid.Base;

public class Account : MonoBehaviourExt
{
    [SerializeField] private int _moneyIncrease = 10;
    [SerializeField] private string _fieldName;

    private int _money = 0;
    private float _currentTime = 0;

    public int Money => _money;

    [OnUpdate]
    private void IncreaseMoney()
    {
        if (_currentTime >= 1f)
        {
            _currentTime = 0;
            _money += _moneyIncrease;

            Model.Set(_fieldName, _money);
        }
        else
        {
            _currentTime += Time.deltaTime;
        }
    }
}