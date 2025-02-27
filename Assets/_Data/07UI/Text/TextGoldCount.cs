using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextGoldCount : TextAbstract
{

    private void Start()
    {
        ObserverManager.AddObserver(Const.TextGoldCount, this.LoadGoldCount);
    }

    private void OnDestroy()
    {
        ObserverManager.RemoveObserver(Const.TextGoldCount, this.LoadGoldCount);
    }
    protected override void LoadGoldCount()
    {
        ItemInventory item = InventoryManager.Instance.Monies().FindItem(ItemCode.Gold);
        if (item == null) goldCount = "0";
        else
            goldCount = item.itemCount.ToString();

        this.textGoldCount.text = goldCount;
    }

    
}
