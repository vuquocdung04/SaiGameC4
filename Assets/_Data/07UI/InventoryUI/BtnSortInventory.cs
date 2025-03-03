using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnSortInventory : ButtonAbstract
{
    [Header("BtnSortInventory")]
    [SerializeField] protected InventoryUI inventoryUI;
    public InventoryUI InventoryUI => inventoryUI;
    protected override void OnClick()
    {
        if (inventoryUI.BtnItems.Count < 1) return;

        foreach (var itemBtn in inventoryUI.BtnItems)
        {

        }
    }

    #region LoadComponent

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadInventoryUI();
    }
    protected virtual void LoadInventoryUI()
    {
        if (this.inventoryUI != null) return;
        this.inventoryUI = GetComponentInParent<InventoryUI>();
        Debug.LogWarning(transform.name + ": LoadInventoryUI", gameObject);
    }

    #endregion
}
