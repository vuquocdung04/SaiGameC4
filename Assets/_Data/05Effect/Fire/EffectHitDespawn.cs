using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectHitDespawn : Despawn<EffectHitCtrl>
{
    protected override void ResetValues()
    {
        base.ResetValues();
        this.timeLife = 3f;
    }
}
