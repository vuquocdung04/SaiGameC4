using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ItemInventory
{
    public int itemId;
    public string itemName;
    public ItemProfileSO itemProfile;
    public int itemCount;

    public virtual bool Deduct(int number)
    {
        if (this.itemCount < number) return false;
        this.itemCount -= number;
        return true;
    }
}
