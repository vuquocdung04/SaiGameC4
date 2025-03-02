using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EffectCtrl : PoolObj
{
    [SerializeField] protected EffectPrefabs effectPrefabs;
    public EffectPrefabs EffectPrefabs => effectPrefabs;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEffectPrefabs();
    }

    protected virtual void LoadEffectPrefabs()
    {
        if (this.effectPrefabs != null) return;
        this.effectPrefabs = GetComponentInParent<EffectPrefabs>();

        Debug.LogWarning(transform.name + ": LoadEffectPrefabs", gameObject);
    }
}
