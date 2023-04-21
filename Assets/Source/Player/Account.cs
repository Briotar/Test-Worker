using UnityEngine;
using AxGrid;
using AxGrid.Base;
using AxGrid.Model;

public class Account : MonoBehaviourExtBind
{
    [SerializeField] private string _moneyCount;
    [SerializeField] private string _increaseMoneyCount;

    private int _money = 0;
    private float _currentTime = 0;
    private int _currenMoneyIncrease;

    [OnUpdate]
    private void ChangeMoneyCount()
    {
        if(Settings.Fsm.CurrentStateName == "StayState")
        {
            if (_currentTime >= 1f)
            {
                _currentTime = 0;
                _money += _currenMoneyIncrease;

                Model.Set(_moneyCount, _money);
            }
            else
            {
                _currentTime += Time.deltaTime;
            }
        }
    }

    [Bind("On{_increaseMoneyCount}Changed")]
    public void OnMoneyChanged(int value)
    {
        _currenMoneyIncrease = value;
    }
}