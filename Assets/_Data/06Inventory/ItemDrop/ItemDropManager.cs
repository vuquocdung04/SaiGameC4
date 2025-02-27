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

    public float spawnHeight = 1f;
    public float forceAmount = 5f;
    public int numberOfItems = 10;


    // drop enemy
    public virtual void Drop(ItemCode itemCode, int dropCoin, Vector3 dropPos)
    {
        Vector3 spawnPos = dropPos + new Vector3(Random.Range(-2, 2), spawnHeight);
        ItemDropCtrl itemDropCtrl = this.itemDropPrefabs.GetByName("Gold");
        ItemDropCtrl newItem = this.itemDropSpawner.Spawn(itemDropCtrl, dropPos);

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
