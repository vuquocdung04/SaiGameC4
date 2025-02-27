using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ItemDropCtrl : PoolObj
{
    [Header("ItemDropCtrl")]
    [SerializeField] protected Rigidbody _rigi;
    public Rigidbody Rigi => _rigi;


    protected InventoryCodeName inventoryCodeName = InventoryCodeName.Items;
    public InventoryCodeName InventoryCodeName => inventoryCodeName;
    protected ItemCode itemCode;
    public ItemCode ItemCode => itemCode;
    protected int itemCount = 1;
    public int ItemCount => itemCount;

    public virtual void SetValue(ItemCode itemCode, int itemCount)
    {
        this.itemCode = itemCode;
        this.itemCount = itemCount;
    }
    public virtual void SetValue(ItemCode itemCode, int itemCount, InventoryCodeName inventoryCodeName)
    {
        this.inventoryCodeName = inventoryCodeName;
        this.itemCount = itemCount;
        this.itemCode = itemCode;
    }


    public override string GetName()
    {
        return "ItemDrop";
    }

    #region LoadComponent
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadRigidbody();
    }
    protected virtual void LoadRigidbody()
    {
        if (this._rigi != null) return;
        this._rigi = GetComponent<Rigidbody>();

        Debug.LogWarning(transform.name + ": LoadRigidbody", gameObject);
    }

    #endregion
}
