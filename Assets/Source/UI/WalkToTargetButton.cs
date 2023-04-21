using UnityEngine;
using AxGrid;
using AxGrid.Base;
using AxGrid.Model;

[RequireComponent(typeof(UnityEngine.UI.Button))]
public class WalkToTargetButton : MonoBehaviourExt
{
    [SerializeField] private Transform _target;

    private UnityEngine.UI.Button _button;

    [OnAwake]
    public void Init()
    {
        _button = GetComponent<UnityEngine.UI.Button>();
        _button.onClick.AddListener(this.OnClick);
    }

    private void OnClick()
    {
        Settings.Invoke("NewTarget", _target);
        _button.interactable = false;
    }
}