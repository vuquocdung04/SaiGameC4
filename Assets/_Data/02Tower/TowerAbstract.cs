using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class TowerAbstract : DungMonoBehaviour
{
    [Header("TowerAbstract")]
    [SerializeField] protected TowerCtrl towerCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTowerCtrl();
    }

    protected virtual void LoadTowerCtrl()
    {
        if (this.towerCtrl != null) return;
        this.towerCtrl = this.transform.parent.GetComponent<TowerCtrl>();
        Debug.LogWarning(transform.name + ": LoadTowerCtrl", gameObject);
    }
}
