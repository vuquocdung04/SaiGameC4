using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/ItemProfile",order = 1)]
public class ItemProfileSO : ScriptableObject
{
    public ItemCode itemCode;
    public string itemName;
    // co gop chung duoc khong
    public bool isStackable = false;
}
