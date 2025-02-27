using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnCloseInventory : ButtonAbstract
{

    public virtual void CloseInventoryUI()
    {
        InventoryUI.Instance.Hide();
    }
    protected override void OnClick()
    {
        this.CloseInventoryUI();
    }
}
