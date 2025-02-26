using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InventoryCtrl : DungMonoBehaviour
{
    protected List<ItemInventory> items = new();

    public abstract InventoryCodeName GetName();

    public virtual void AddItem(ItemInventory itemInventory)
    {
        this.items.Add(itemInventory);
    }
}
