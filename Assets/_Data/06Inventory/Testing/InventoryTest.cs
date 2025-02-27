using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
public class InventoryTest : DungMonoBehaviour
{
    [OnInspectorGUI, GUIColor(0, 0, 0, 0)]
    private void Space() => GUILayout.Space(20);

    [Button("Gold-Add", ButtonSizes.Medium)]
    protected virtual void AddTestGold(int count)
    {
        InventoryCtrl wands = InventoryManager.Instance.Monies();

        ItemInventory wand = new();
        wand.itemProfile = InventoryManager.Instance.GetProfileByCode(ItemCode.Gold);
        wand.itemName = "Gold";
        wand.itemCount = count;
        wands.AddItem(wand);

        ObserverManager.Notify(Const.TextGoldCount);
    }

    [Button("Gold-Remove", ButtonSizes.Large)]
    protected virtual void RemoveTestGold(int count)
    {
        InventoryCtrl wands = InventoryManager.Instance.Monies();

        ItemInventory wand = new();
        wand.itemProfile = InventoryManager.Instance.GetProfileByCode(ItemCode.Gold);
        wand.itemName = "Gold";
        wand.itemCount = count;
        wands.RemoveItem(wand);

        ObserverManager.Notify(Const.TextGoldCount);
    }



    [Button("Item-Add", ButtonSizes.Medium)]
    protected virtual void AddTestItem(int count)
    {
        InventoryCtrl wands = InventoryManager.Instance.Items();

        for (int i = 0; i < count; i++)
        {
            ItemInventory wand = new();
            wand.itemProfile = InventoryManager.Instance.GetProfileByCode(ItemCode.Wand);
            wand.itemName = "Wand";
            wand.itemCount = 1;
            wands.AddItem(wand);
            ObserverManager.Notify(Const.ShowWand);
        }
    }
    [Button("Item-Remove", ButtonSizes.Medium)]
    protected virtual void RemoveTestItem(int count)
    {
        InventoryCtrl wands = InventoryManager.Instance.Items();

        for (int i = 0; i < count; i++)
        {
            ItemInventory wand = new();
            wand.itemProfile = InventoryManager.Instance.GetProfileByCode(ItemCode.Wand);
            wand.itemName = "Wand";
            wand.itemCount = 1;
            wands.RemoveItem(wand);
            ObserverManager.Notify(Const.ShowWand);
        }
    }

}
