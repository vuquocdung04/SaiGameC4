using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EffectFallAbstract : EffectCtrl
{
    [Header("EffectFallAbstract")]
    [SerializeField] protected FallToTarget fallToTarget;
    public FallToTarget FallToTarget => fallToTarget;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadFallingToTarget();
    }
    protected virtual void LoadFallingToTarget()
    {
        if (this.fallToTarget != null) return;
        this.fallToTarget = GetComponentInChildren<FallToTarget>();

        Debug.LogWarning(transform.name + ": LoadFallingToTarget", gameObject);
    }
}
