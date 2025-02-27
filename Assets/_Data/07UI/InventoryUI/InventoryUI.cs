using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : Singleton<InventoryUI>
{
    [SerializeField] protected bool isShow = false;
    bool IsShow => isShow;

    [SerializeField] protected BtnItemInventory itemInventory;
    private void Start()
    {
        this.Hide();
        this.HideDefaultItemInventory();
    }

    public virtual void Hide()
    {
        gameObject.SetActive(false);
        this.isShow = false;
    }

    public virtual void Show()
    {
        gameObject.SetActive(true);
        this.isShow = true;
    }

    public virtual void Toggle()
    {
        if (this.isShow) this.Hide();
        else this.Show();
    }

    protected virtual void HideDefaultItemInventory()
    {
        this.itemInventory.gameObject.SetActive(false);
    }

    #region LoadComponent
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBtnItemInventory();
    }
    protected virtual void LoadBtnItemInventory()
    {
        if (this.itemInventory != null) return;
        this.itemInventory = GetComponentInChildren<BtnItemInventory>();

        Debug.LogWarning(transform.name + ": LoadBtnItemInventory", gameObject);
    }

    #endregion
}
