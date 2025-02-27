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

    string Gold = "Gold";

    protected float spawnHeight = 1f;
    protected float forceAmount = 5f;
    protected int numberOfItems = 10;


    // drop enemy
    public virtual void Drop(ItemCode itemCode, int dropCount, Vector3 dropPos)
    {
        Vector3 spawnPos = dropPos + new Vector3(Random.Range(-2, 2), spawnHeight);
        ItemDropCtrl itemDropCtrl = this.itemDropPrefabs.GetByName(this.Gold);
        ItemDropCtrl newItem = this.itemDropSpawner.Spawn(itemDropCtrl, dropPos);

        newItem.SetValue(itemCode, dropCount, InventoryCodeName.Monies);

        newItem.gameObject.SetActive(true);

        Vector3 randomDirection = Random.onUnitSphere;
        randomDirection.y = Mathf.Abs(randomDirection.y);
        newItem.Rigi.AddForce(randomDirection * forceAmount, ForceMode.Impulse);



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
