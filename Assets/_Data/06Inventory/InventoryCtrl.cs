using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InventoryCtrl : DungMonoBehaviour
{
    [SerializeField] protected List<ItemInventory> items = new();
    public List<ItemInventory> Items => items;
    public abstract InventoryCodeName GetName();

    public virtual void AddItem(ItemInventory itemInventory)
    {
        ItemInventory itemExit = this.FindItem(itemInventory.itemProfile.itemCode);

        if(!itemInventory.itemProfile.isStackable || itemExit == null)
        {
            itemInventory.itemId = Random.Range(0,999999999);
            this.items.Add(itemInventory);
            return;
        }

        itemExit.itemCount += itemInventory.itemCount;
    }

    public virtual ItemInventory FindItem(ItemCode itemCode)
    {
        foreach (var itemInventory in this.items)
        {
            if(itemInventory.itemProfile.itemCode == itemCode) return itemInventory;
        }
        return null;
    }
}
