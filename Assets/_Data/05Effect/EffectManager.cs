using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : Singleton<EffectManager>
{
    [SerializeField] protected EffectSpawner spawner; 
    public EffectSpawner Spawner => spawner;

    [SerializeField] protected EffectPrefabs effectPrefabs;
    public EffectPrefabs EffectPrefabs => effectPrefabs;
    #region LoadComponents
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSpawner();
        this.LoadPrefabs();
    }
    protected virtual void LoadSpawner()
    {
        if (this.spawner != null) return;
        this.spawner = GetComponentInChildren<EffectSpawner>();
        Debug.LogWarning(transform.name + ": LoadSpawner", gameObject);
    }
    protected virtual void LoadPrefabs()
    {
        if (this.effectPrefabs != null) return;
        this.effectPrefabs = GetComponentInChildren<EffectPrefabs>();
        Debug.LogWarning(transform.name + ": LoadPrefabs", gameObject);
    }
    #endregion
}
