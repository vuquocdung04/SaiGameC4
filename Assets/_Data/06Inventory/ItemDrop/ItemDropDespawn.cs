using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDropDespawn : Despawn<ItemDropCtrl>
{
    public override void DoDespawn()
    {
        ItemDropCtrl itemDropCtrl = (ItemDropCtrl)this.parent;

        ItemInventory item = new();
        item.itemProfile = InventoryManager.Instance.GetProfileByCode(itemDropCtrl.ItemCode);
        item.itemCount = itemDropCtrl.ItemCount;
        // drop thi add item roi vao day
        // Monies() == tuong duong voi InventoryCtrl ctrl = this.GetByName(InventoryCodeName.Monies);
        InventoryManager.Instance.GetByCodeName(itemDropCtrl.InventoryCodeName).AddItem(item);
        base.DoDespawn();
        ObserverManager.Notify(Const.TextGoldCount);
    }
}
