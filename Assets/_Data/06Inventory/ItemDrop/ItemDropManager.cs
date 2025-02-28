using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDropManager : Singleton<ItemDropManager>
{
    [Header("ItemDropManager")]
    [SerializeField] protected ItemDropSpawner itemDropSpawner;
    public ItemDropSpawner ItemDropSpawner => itemDropSpawner;

    [SerializeField] protected ItemDropPrefabs itemDropPrefabs;
    public ItemDropPrefabs ItemDropPrefabs => itemDropPrefabs;

    [SerializeField] float spawnHeight = 0.3f;
    [SerializeField] float forceAmount = 0.3f;


    public virtual void DropMany(ItemCode itemCode, int dropCount,Vector3 tranformPos)
    {
        for (int i = 0; i < dropCount; i++)
        {
            ItemDropManager.Instance.Drop(itemCode, 1, tranformPos);
        }
    }

    // drop enemy
    public virtual void Drop(ItemCode itemCode, int dropCount, Vector3 dropPos)
    {
        Vector3 spawnPos = dropPos + new Vector3(Random.Range(-2, 2), spawnHeight);
        ItemDropCtrl itemDropCtrl = this.itemDropPrefabs.GetByName(itemCode.ToString());
        if(itemDropCtrl == null) itemDropCtrl = this.ItemDropPrefabs.GetByName("DefaultDrop");
        ItemDropCtrl newItem = this.itemDropSpawner.Spawn(itemDropCtrl, dropPos);

        if (itemDropCtrl == this.itemDropPrefabs.GetByName("Gold"))
        {
            newItem.SetValue(itemCode, dropCount, InventoryCodeName.Currency);
        }
        else
        {

            newItem.SetValue(itemCode, dropCount, InventoryCodeName.Items);
        }

        newItem.gameObject.SetActive(true);

        Vector3 randomDirection = Random.onUnitSphere;
        randomDirection.y = Mathf.Abs(randomDirection.y);
        newItem.Rigi.AddForce(randomDirection * forceAmount);



    }


    #region LoadComponent
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadDropSpawner();
        this.LoadItemDropPrefabs();
    }
    protected virtual void LoadDropSpawner()
    {
        if (this.itemDropSpawner != null) return;
        this.itemDropSpawner = GetComponent<ItemDropSpawner>();

        Debug.LogWarning(transform.name + ": LoadSpawner", gameObject);
    }

    protected virtual void LoadItemDropPrefabs()
    {
        if (this.itemDropPrefabs != null) return;
        this.itemDropPrefabs = GetComponentInChildren<ItemDropPrefabs>();

        Debug.LogWarning(transform.name + ": LoadItemDropPrefabs", gameObject);
    }

    #endregion

}
