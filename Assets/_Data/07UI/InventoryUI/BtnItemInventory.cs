using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BtnItemInventory : ButtonAbstract
{
    [Header("BtnItemInventory")]
    [SerializeField] protected TMP_Text itemTextCount;
    [SerializeField] protected Image itemSprite;


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
        this.itemTextCount.text = itemInventory.itemCount.ToString();
        this.itemSprite.sprite = itemInventory.itemProfile.sprite;
        if (this.itemInventory.itemCount == 0) Destroy(gameObject);
    }

    #region LoadComponent

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTextCount();
        this.LoadItemSprite();
    }
    protected virtual void LoadTextCount()
    {
        if (this.itemTextCount != null) return;
        this.itemTextCount = transform.Find("Badge").Find("Image").Find("ItemCount").GetComponent<TMP_Text>();

        Debug.LogWarning(transform.name + ": LoadTextCount", gameObject);
    }
    protected virtual void LoadItemSprite()
    {
        if (this.itemSprite != null) return;
        this.itemSprite = transform.Find("ItemSprite").GetComponent<Image>();

        Debug.LogWarning(transform.name + ": LoadItemSprite", gameObject);
    }
    #endregion
}
