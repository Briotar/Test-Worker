using UnityEngine;
using UnityEngine.UI;
using AxGrid;
using AxGrid.Base;

public class ButtonsManager : MonoBehaviourExt
{
    [SerializeField] private string _increaseMoneyCount;
    [SerializeField] private int _moneyIncreaseConst = 10;
    [SerializeField] private Button _homeButton;
    [SerializeField] private Button _workButton;
    [SerializeField] private Button _shopButton;

    [OnAwake]
    public void Init()
    {
        _homeButton.onClick.AddListener(this.OnHomeClick);
        _workButton.onClick.AddListener(this.OnWorkClick);
        _shopButton.onClick.AddListener(this.OnShopClick);
    }

    private void OnHomeClick()
    {
        Model.Set(_increaseMoneyCount, 0);

        _workButton.interactable = true;
        _shopButton.interactable = true;
    }
    private void OnWorkClick()
    {
        Model.Set(_increaseMoneyCount, _moneyIncreaseConst);

        _homeButton.interactable = true;
        _shopButton.interactable = true;
    }
    private void OnShopClick()
    {
        Model.Set(_increaseMoneyCount, -_moneyIncreaseConst);

        _homeButton.interactable = true;
        _workButton.interactable = true;
    }
}