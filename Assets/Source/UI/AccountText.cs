using UnityEngine;
using AxGrid.Model;
using AxGrid.Base;
using AxGrid.Tools.Binders;
using TMPro;

[RequireComponent(typeof(TMP_Text))]
public class AccountText : MonoBehaviourExtBind
{
    private TMP_Text _text;

    [OnStart]
    private void Init()
    {
        _text = GetComponent<TMP_Text>();
    }

    [Bind("OnmoneyChanged")]
    public void OnMoneyChanged(string value)
    {
        _text.text = value;
    }
}