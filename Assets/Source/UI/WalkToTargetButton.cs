using UnityEngine;
using AxGrid.Base;

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
        Debug.Log("Button!" + _target.gameObject.name);
    }
}