using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class BtnItemInventory : ButtonAbstract
{
    [Header("BtnItemInventory")]
    [SerializeField] protected TMP_Text itemTextName;
    [SerializeField] protected TMP_Text itemTextCount;


    protected ItemInventory itemInventory;
    public ItemInventory ItemInventory => itemInventory;

    /// <summary>
    /// Observer
    /// </summary>
    protected override void Start()
    {
        
    }

    private void FixedUpdate()
    {
        this.ItemUpdating();
    }


    public virtual void SetItem(ItemInventory itemInventory)
    {
        this.itemInventory = itemInventory;
    }
    protected override void OnClick()
    {
        Debug.Log("Item Click");
    }

    protected virtual void ItemUpdating()
    {
        this.itemTextName.text = itemInventory.itemName;
        this.itemTextCount.text = itemInventory.itemCount.ToString();

        if (this.itemInventory.itemCount == 0) Destroy(gameObject);
    }

    #region LoadComponent

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTextCount();
        this.LoadTextName();
    }
    protected virtual void LoadTextCount()
    {
        if (this.itemTextCount != null) return;
        this.itemTextCount = transform.Find("ItemCount").GetComponent<TMP_Text>();

        Debug.LogWarning(transform.name + ": LoadTextCount", gameObject);
    }
    protected virtual void LoadTextName()
    {
        if (this.itemTextName != null) return;
        this.itemTextName = transform.Find("ItemName").GetComponent<TMP_Text>();

        Debug.LogWarning(transform.name + ": LoadTextName", gameObject);
    }

    #endregion
}
