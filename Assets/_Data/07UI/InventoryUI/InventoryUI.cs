using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : Singleton<InventoryUI>
{
    [SerializeField] protected bool isShow = false;
    bool IsShow => isShow;

    [SerializeField] protected Transform showInventory;
    [SerializeField] protected BtnItemInventory defaultItemInventoryUI;
    protected List<BtnItemInventory> btnItems = new();
    private void Start()
    {
        this.Hide();
        this.HideDefaultItemInventory();
        ObserverManager.AddObserver(Const.ShowWand,ItemUpdating);
        ObserverManager.AddObserver(Const.HotKeyUI,this.HotKeyToggleInventory);
    }

    private void OnDestroy()
    {
        ObserverManager.RemoveObserver(Const.ShowWand,ItemUpdating);
        ObserverManager.RemoveObserver(Const.HotKeyUI, this.HotKeyToggleInventory);
    }

    protected virtual void HotKeyToggleInventory()
    {
        if (InputHotKey.Instance.IsToggleInventoryUI) this.Toggle();
    }

    public virtual void Hide()
    {
        this.showInventory.gameObject.SetActive(false);
        this.isShow = false;
    }

    public virtual void Show()
    {
        this.showInventory.gameObject.SetActive(true);
        this.isShow = true;
    }

    public virtual void Toggle()
    {
        if (this.isShow) this.Hide();
        else this.Show();
    }

    protected virtual void HideDefaultItemInventory()
    {
        this.defaultItemInventoryUI.gameObject.SetActive(false);
    }

    protected virtual void ItemUpdating()
    {
        InventoryCtrl itemInvCtrl = InventoryManager.Instance.Items();
        foreach (ItemInventory itemInventory in itemInvCtrl.Items)
        {
            BtnItemInventory newBtnItemUI = this.GetExitsItem(itemInventory);
            if(newBtnItemUI == null)
            {
                newBtnItemUI = Instantiate(this.defaultItemInventoryUI);
                newBtnItemUI.transform.SetParent(this.defaultItemInventoryUI.transform.parent);
                newBtnItemUI.SetItem(itemInventory);
                newBtnItemUI.transform.localScale = Vector3.one;
                newBtnItemUI.gameObject.SetActive(true);

                newBtnItemUI.name = itemInventory.itemName + "_" + itemInventory.itemId;
                this.btnItems.Add(newBtnItemUI);
            }

        }
    }

    protected virtual BtnItemInventory GetExitsItem(ItemInventory itemInventory)
    {
        foreach (BtnItemInventory btnItemInventory in this.btnItems)
        {
            if (btnItemInventory.ItemInventory.itemId == itemInventory.itemId) 
                return btnItemInventory;
        }
        return null;
    }

    #region LoadComponent
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBtnItemInventory();
        this.LoadShowInventory();
    }
    protected virtual void LoadBtnItemInventory()
    {
        if (this.defaultItemInventoryUI != null) return;
        this.defaultItemInventoryUI = GetComponentInChildren<BtnItemInventory>();

        Debug.LogWarning(transform.name + ": LoadBtnItemInventory", gameObject);
    }

    protected virtual void LoadShowInventory()
    {
        if (this.showInventory != null) return;
        this.showInventory = transform.Find("ShowInventory");

        Debug.LogWarning(transform.name + ": LoadShowInventory", gameObject);
    }

    #endregion
}
