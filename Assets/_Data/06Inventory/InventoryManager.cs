using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
public class InventoryManager : Singleton<InventoryManager>
{
    [Header("Inventory Manager")]
    [SerializeField] protected List<InventoryCtrl> inventories;
    [SerializeField] protected List<ItemProfileSO> itemProfiles;


    // lay item trong danh sach
    public virtual InventoryCtrl GetByCodeName(InventoryCodeName inventoryName)
    {
        foreach (InventoryCtrl inventoryCtrl in this.inventories)
        {
            if (inventoryCtrl.GetName() == inventoryName) return inventoryCtrl;
        }
        return null;
    }

    // lay item profile trong danh sach
    public virtual ItemProfileSO GetProfileByCode(ItemCode itemCodeName)
    {
        foreach (ItemProfileSO item in this.itemProfiles)
        {
            if(item.itemCode == itemCodeName) return item;
        }
        return null;
    }

    //tuong duong InventoryCtrl ctrl = this.GetByName(InventoryCodeName.Monies);
    public virtual InventoryCtrl Monies()
    {
        return this.GetByCodeName(InventoryCodeName.Monies);
    }

    // tuong duong InventoryCtrl ctrl = this.GetByName(InventoryCodeName.Items);
    public virtual InventoryCtrl Items()
    {
        return this.GetByCodeName(InventoryCodeName.Items);
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
