using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextGoldCount : DungMonoBehaviour
{
    [SerializeField] protected TMP_Text textGoldCount;
    string goldCount;
    private void Start()
    {
        ObserverManager.AddObserver(Const.TextGoldCount, this.LoadGoldCount);
    }

    private void OnDestroy()
    {
        ObserverManager.RemoveObserver(Const.TextGoldCount, this.LoadGoldCount);
    }
    protected virtual void LoadGoldCount()
    {
        ItemInventory item = InventoryManager.Instance.Monies().FindItem(ItemCode.Gold);
        if (item == null) goldCount = "0";
        else
            goldCount = item.itemCount.ToString();

        this.textGoldCount.text = goldCount;
    }

    #region LoadComponent
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTextPro();
    }
    protected virtual void LoadTextPro()
    {
        if (this.textGoldCount != null) return;
        this.textGoldCount = GetComponent<TMP_Text>();

        Debug.LogWarning(transform.name + ": LoadTextPro", gameObject);
    }

    #endregion
}
