using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EffectFlyAbstract : EffectCtrl
{
    [Header("EffectFlyAbstract")]
    [SerializeField] protected FlyToTarget flyToTarget;
    public FlyToTarget FlyToTarget => flyToTarget;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadFlyingToTarget();
    }
    protected virtual void LoadFlyingToTarget()
    {
        if (this.flyToTarget != null) return;
        this.flyToTarget = GetComponentInChildren<FlyToTarget>();

        Debug.LogWarning(transform.name + ": LoadFlyingToTarget", gameObject);
    }
}
