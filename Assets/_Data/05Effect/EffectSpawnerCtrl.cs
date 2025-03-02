using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectSpawnerCtrl : Singleton<EffectSpawnerCtrl>
{
    [SerializeField] protected EffectSpawner effectSpawner;
    public EffectSpawner EffectSpawner => effectSpawner;

    [SerializeField] protected EffectPrefabs effectPrefabs;
    public EffectPrefabs EffectPrefabs => effectPrefabs;

    #region LoadComponents
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEffectSpawner();
        this.LoadEffectPrefabs();
    }
    protected virtual void LoadEffectSpawner()
    {
        if (this.effectSpawner != null) return;
        this.effectSpawner = GetComponent<EffectSpawner>();
        Debug.LogWarning(transform.name + ": LoadEffectSpawner", gameObject);

    }
    protected virtual void LoadEffectPrefabs()
    {
        if (this.effectPrefabs != null) return;
        this.effectPrefabs = GameObject.FindAnyObjectByType<EffectPrefabs>();
        Debug.LogWarning(transform.name + ": LoadEffectPrefabs", gameObject);

    }
    #endregion
}
