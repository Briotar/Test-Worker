using UnityEngine;
using AxGrid.Model;
using AxGrid.Base;
using TMPro;

[RequireComponent(typeof(TMP_Text))]
public class AccountText : MonoBehaviourExtBind
{
    [SerializeField] private string _fieldName;

    private TMP_Text _text;

    [OnStart]
    private void Init()
    {
        _text = GetComponent<TMP_Text>();
    }

    [Bind("On{_fieldName}Changed")]
    public void OnMoneyChanged(string value)
    {
        _text.text = value;
    }
}