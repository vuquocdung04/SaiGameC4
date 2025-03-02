using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectPrefabs : PoolPrefabs<EffectCtrl>
{
    [Header("EffectPrefabs")]
    [SerializeField] protected EffectSpawnerCtrl effectSpawnerCtrl;
    public EffectSpawnerCtrl EffectSpawnerCtrl => effectSpawnerCtrl;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEffectSpawnerCtrl();
    }

    protected virtual void LoadEffectSpawnerCtrl()
    {
        if (this.effectSpawnerCtrl != null) return;
        this.effectSpawnerCtrl = GameObject.FindAnyObjectByType<EffectSpawnerCtrl>();

        Debug.LogWarning(transform.name + ": LoadEffectSpawnerCtrl", gameObject);
    }

}
