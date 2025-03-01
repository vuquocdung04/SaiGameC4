using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LevelByItem : LevelAbstract
{
    [Header("Level By Item")]
    [SerializeField] protected ItemInventory playerExp;

    protected override int GetCurrentExp()
    {
        if (this.GetPlayerExp() == null) return 0;
        return this.GetPlayerExp().itemCount;
    }

    protected override bool DeductExp(int exp)
    {
        return this.GetPlayerExp().Deduct(exp);
    }

    protected virtual ItemInventory GetPlayerExp()
    {
        if (this.playerExp == null || this.playerExp.itemId == 0)
            // Tao kieu item co kieu tra ve la Monies 
            this.playerExp = InventoryManager.Instance.Monies().FindItem(ItemCode.PlayerExp);
        return playerExp;
    }
}
