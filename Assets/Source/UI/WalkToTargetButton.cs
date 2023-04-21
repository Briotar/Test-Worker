using UnityEngine;
using AxGrid;
using AxGrid.Base;
using AxGrid.Model;

[RequireComponent(typeof(UnityEngine.UI.Button))]
public class WalkToTargetButton : MonoBehaviourExtBind
{
    [SerializeField] private string _gameObjName;
    [SerializeField] private Transform _target;

    private UnityEngine.UI.Button _button;

    [OnAwake]
    public void Init()
    {
        _button = GetComponent<UnityEngine.UI.Button>();
    }

    [Bind("On{_gameObjName}Click")]
    private void OnClick()
    {
        Settings.Invoke("NewTarget", _target);
        _button.interactable = false;
    }

    [Bind("SoundPlay")]
    private void OnButton()
    {
        _button.interactable = true;
    }
}