using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TowerShooting : TowerAbstract
{
    [SerializeField] protected EnemyCtrl enemyTarget;
    private void FixedUpdate()
    {
        this.LookAtTarget();
    }

    protected virtual void LookAtTarget()
    {
        if (this.enemyTarget == null) return;
        this.towerCtrl.Rotator.LookAt(this.enemyTarget.TowerTargetable.transform.position);
    }


}
