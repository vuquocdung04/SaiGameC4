using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDespawn : Despawn<EnemyCtrl>
{
    protected override void ResetValues()
    {
        base.ResetValues();
        this.isDespawnByTime = false;
    }
}
