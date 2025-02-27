using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnInventoryToggle : ButtonAbstract
{
    protected override void OnClick()
    {
        InventoryUI.Instance.Toggle();
    }
}
