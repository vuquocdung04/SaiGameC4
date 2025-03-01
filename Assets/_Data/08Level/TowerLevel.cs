using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerLevel : LevelAbstract
{
    [Header("TowerLevel")]
    [SerializeField] protected TowerCtrl towerCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTowerCtrl();
    }

    protected virtual void LoadTowerCtrl()
    {
        if (this.towerCtrl != null) return;
        this.towerCtrl = GetComponentInParent<TowerCtrl>();
        //this.towerCtrl = this.transform.parent.GetComponent<TowerCtrl>();
        Debug.LogWarning(transform.name + ": LoadTowerCtrl", gameObject);
    }

    protected override bool DeductExp(int exp)
    {
        return this.towerCtrl.TowerShooting.DeductKillCount(exp);
    }

    protected override int GetCurrentExp()
    {
        return this.towerCtrl.TowerShooting.KillCount;
    }
}
