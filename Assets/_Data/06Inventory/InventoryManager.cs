using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : Singleton<InventoryManager>
{
    [Header("Inventory Manager")]
    [SerializeField] protected List<InventoryCtrl> inventories = new();

    private void Start()
    {
        this.AddTestItem();
    }

    protected virtual void AddTestItem()
    {
        InventoryCtrl ctrl = this.GetByName(InventoryCodeName.Monies);

        ItemInventory item = new()
        {
            itemName = "Gold",
            itemCount = 4
        };
        ctrl.AddItem(item);
    }

    public virtual InventoryCtrl GetByName(InventoryCodeName inventoryName)
    {
        foreach (InventoryCtrl inventoryCtrl in this.inventories)
        {
            if (inventoryCtrl.GetName() == inventoryName) return inventoryCtrl;
        }
        return null;
    }

    #region LoadComponents
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadInventories();
    }

    protected virtual void LoadInventories()
    {
        if (this.inventories.Count > 0) return;
        foreach (Transform child in transform)
        {
            InventoryCtrl inventoryCtrl = child.GetComponent<InventoryCtrl>();
            if (inventoryCtrl == null) continue;
            inventories.Add(inventoryCtrl);
        }
        Debug.LogWarning(transform.name + ": LoadInventories", gameObject);
    }

    #endregion

}
