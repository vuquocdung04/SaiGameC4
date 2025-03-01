using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHpBar : SliderHpBar
{
    [SerializeField] protected EnemyCtrl enemyCtrl;
    protected override float GetValue()
    {
        return (float)this.enemyCtrl.EnemyDamageReceiver.CurrentHP/(float)this.enemyCtrl.EnemyDamageReceiver.MaxHp;
    }

    #region LoadComponent

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemyCtrl();
    }
    protected virtual void LoadEnemyCtrl()
    {
        if (this.enemyCtrl != null) return;
        this.enemyCtrl = GetComponentInParent<EnemyCtrl>();

        Debug.LogWarning(transform.name + ": LoadEnemyCtrl", gameObject);
    }

    #endregion
}
