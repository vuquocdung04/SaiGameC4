using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPrefabs : EnemyManagerAbstract
{
    [Header("Enemy Prefabs")]
    [SerializeField] protected List<EnemyCtrl> enemyCtrls = new();

    #region LoadComponents
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemyCtrl();
    }

    protected virtual void LoadEnemyCtrl()
    {
        if (this.enemyCtrls.Count > 0) return;
        foreach (Transform child in transform)
        {
            EnemyCtrl enemyCtrl = child.GetComponent<EnemyCtrl>();
            if(enemyCtrl) this.enemyCtrls.Add(enemyCtrl);
        }

        this.HidePrefabs();
        Debug.LogWarning(transform.name + ": LoadEnemyCtrl", gameObject);
    }

    #endregion

    protected virtual void HidePrefabs()
    {
        foreach (EnemyCtrl enemyCtrl in this.enemyCtrls)
        {
            enemyCtrl.gameObject.SetActive(false);
        }
    }

    //Ramdom enemy
    public virtual EnemyCtrl GetRamdom()
    {
        int rand = Random.Range(0,this.enemyCtrls.Count);
        return this.enemyCtrls[rand];
    }
}
