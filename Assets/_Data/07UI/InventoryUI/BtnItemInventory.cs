using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BtnItemInventory : ButtonAbstract
{
    [Header("BtnItemInventory")]
    [SerializeField] protected Image itemImage;
    [SerializeField] protected TMP_Text itemTextCount;


    protected ItemInventory itemInventory;
    public ItemInventory ItemInventory => itemInventory;

    protected override void Start()
    {
        ObserverManager.AddObserver(Const.UpdateSpriteBtn, this.BtnItemUpdating);
    }
    private void OnDestroy()
    {
        ObserverManager.RemoveObserver(Const.UpdateSpriteBtn, this.BtnItemUpdating);
    }


    public virtual void SetItem(ItemInventory itemInventory)
    {
        this.itemInventory = itemInventory;
    }
    protected override void OnClick()
    {
        Debug.Log("Item Click");
    }

    //update sprite ui
    protected virtual void BtnItemUpdating()
    {
        this.itemImage.sprite = itemInventory.itemProfile.itemSprite;
        if (this.itemTextCount != null)
        {
            this.itemTextCount.text = "x" + itemInventory.itemCount.ToString();
        }

        if (this.itemInventory.itemCount == 0) Destroy(gameObject);
    }

    #region LoadComponent

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTextCount();
        this.LoadItemImage();
    }
    protected virtual void LoadTextCount()
    {
        if (this.itemTextCount != null) return;
        this.itemTextCount = GetComponentInChildren<TMP_Text>(true) ? GetComponentInChildren<TMP_Text>(true): null;

        Debug.LogWarning(transform.name + ": LoadTextCount", gameObject);
    }
    protected virtual void LoadItemImage()
    {
        if (this.itemImage != null) return;
        this.itemImage = transform.Find("ItemImage").GetComponent<Image>();

        Debug.LogWarning(transform.name + ": LoadItemImage", gameObject);
    }

    #endregion
}
