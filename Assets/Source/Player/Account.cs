using UnityEngine;
using AxGrid;
using AxGrid.Base;
using AxGrid.Model;

public class Account : MonoBehaviourExtBind
{
    [SerializeField] private string _moneyCount;
    [SerializeField] private int _constIncreaseMoney = 10;

    private int _money = 0;
    private float _currentTime = 0;
    private int _currenMoneyIncrease;

    [OnStart]
    private void InitMiney()
    {
        Model.Set(_moneyCount, _money);
    }

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

    [Bind("OnHomeButtonClick")]
    private void HomeClick()
    {
        _currenMoneyIncrease = 0;
    }

    [Bind("OnWorkButtonClick")]
    private void WorkClick()
    {
        _currenMoneyIncrease = _constIncreaseMoney;
    }

    [Bind("OnShopButtonClick")]
    private void ShopClick()
    {
        _currenMoneyIncrease = -_constIncreaseMoney;
    }
}