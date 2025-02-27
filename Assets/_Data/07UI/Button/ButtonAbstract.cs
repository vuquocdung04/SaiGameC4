using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class ButtonAbstract : DungMonoBehaviour
{
    [Header("Button Abstract")]
    [SerializeField] protected Button button;

    private void Start()
    {
        this.AddOnClickEvent();
    }

    protected abstract void OnClick();
    protected virtual void AddOnClickEvent()
    {
        this.button.onClick.AddListener(this.OnClick);
    }

    #region LoadComponent
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadButton();
    }
    protected virtual void LoadButton()
    {
        if (this.button != null) return;
        this.button = GetComponent<Button>();

        Debug.LogWarning(transform.name + ": LoadButton", gameObject);
    }

    #endregion
}
