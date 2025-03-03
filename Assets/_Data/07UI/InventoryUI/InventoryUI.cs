using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : Singleton<InventoryUI>
{
    [SerializeField] protected bool isShow = false;
    bool IsShow => isShow;

    [SerializeField] protected Transform showInventory;
    //Btn itemNot stack
    [SerializeField] protected List<BtnItemInventory> ItemInventorys;
    [SerializeField] protected List<BtnItemInventory> btnItems = new();
    public List<BtnItemInventory> BtnItems => btnItems;

    private void Start()
    {
        this.Hide();
        this.HideDefaultItemInventory();
        ObserverManager.AddObserver(Const.UpdateUiInventory,ItemUpdating);
        ObserverManager.AddObserver(Const.HotKeyUI,this.HotKeyToggleInventory);
        ObserverManager.AddObserver(Const.sortItemInventory,this.SortInventory);
    }

    private void OnDestroy()
    {
        ObserverManager.RemoveObserver(Const.UpdateUiInventory, ItemUpdating);
        ObserverManager.RemoveObserver(Const.HotKeyUI, this.HotKeyToggleInventory);
        ObserverManager.RemoveObserver(Const.sortItemInventory, this.SortInventory);
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
        StartCoroutine(WaitTest());
    }

    IEnumerator WaitTest()
    {
        yield return null;
        ObserverManager.Notify(Const.UpdateSpriteBtn);

    }

    public virtual void Toggle()
    {
        if (this.isShow) this.Hide();
        else this.Show();
    }

    protected virtual void HideDefaultItemInventory()
    {
        this.ItemInventorys[0].gameObject.SetActive(false);
        this.ItemInventorys[1].gameObject.SetActive(false);
    }

    protected virtual void ItemUpdating()
    {
        InventoryCtrl itemInvCtrl = InventoryManager.Instance.Items();
        foreach (ItemInventory itemInventory in itemInvCtrl.Items)
        {
            BtnItemInventory newBtnItemUI = this.GetExitsItem(itemInventory);
            if(newBtnItemUI == null)
            {
                if (!itemInventory.itemProfile.isStackable)
                {
                    newBtnItemUI = Instantiate(this.ItemInventorys[0]);
                    StartCoroutine(UpdateSpriteCountUI());
                }
                else
                {
                    newBtnItemUI = Instantiate(this.ItemInventorys[1]);
                    StartCoroutine(UpdateSpriteCountUI());
                }
                newBtnItemUI.transform.SetParent(this.ItemInventorys[0].transform.parent);
                newBtnItemUI.SetItem(itemInventory);
                newBtnItemUI.transform.localScale = Vector3.one;
                newBtnItemUI.gameObject.SetActive(true);

                newBtnItemUI.name = itemInventory.itemName + "_" + itemInventory.itemId;
                this.btnItems.Add(newBtnItemUI);
            }
        }
    }

    /// <summary>
    /// Note: fix 
    /// </summary>
    /// <returns></returns>

    IEnumerator UpdateSpriteCountUI()
    {
        yield return null;
        ObserverManager.Notify(Const.UpdateSpriteBtn);
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

    public virtual void SortInventory()
    {
        btnItems.Sort((a,b)  => b.ItemInventory.itemCount.CompareTo(a.ItemInventory.itemCount));
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
        if (this.ItemInventorys.Count > 0) return;
        BtnItemInventory[] childBtns = GetComponentsInChildren<BtnItemInventory>();
        this.ItemInventorys = new List<BtnItemInventory>(childBtns);

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
