using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDropManager : Singleton<ItemDropManager>
{
    [Header("ItemDropManager")]
    [SerializeField] protected ItemDropSpawner itemDropSpawner;
    public ItemDropSpawner ItemDropSpawner => itemDropSpawner;

    public virtual void Drop(ItemCode itemCode, int dropCoin)
    {

    }


    #region LoadComponent
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadDropSpawner();
    }
    protected virtual void LoadDropSpawner()
    {
        if (this.itemDropSpawner != null) return;
        this.itemDropSpawner = GetComponent<ItemDropSpawner>();

        Debug.LogWarning(transform.name + ": LoadSpawner", gameObject);
    }

    #endregion

}
