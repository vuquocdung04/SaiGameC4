using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AttackAbstract : DungMonoBehaviour
{
    [Header("Attack Abstract")]
    [SerializeField] protected PlayerCtrl playerCtrl;
    [SerializeField] protected EffectSpawner spawner;
    [SerializeField] protected EffectPrefabs prefabs;
    public PlayerCtrl PlayerCtrl => playerCtrl;

    protected void Update()
    {
        this.Attacking();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPlayerCtrl();
        this.LoadEffectSpawner();
    }
    protected virtual void LoadPlayerCtrl()
    {
        if (this.playerCtrl != null) return;
        this.playerCtrl = GetComponentInParent<PlayerCtrl>();

        Debug.LogWarning(transform.name + ": LoadPlayerCtrl", gameObject);
    }

    protected virtual void LoadEffectSpawner()
    {
        if (this.spawner != null) return;
        this.spawner = GameObject.FindAnyObjectByType<EffectSpawner>();
        if (this.prefabs != null) return;
        this.prefabs = GameObject.FindAnyObjectByType<EffectPrefabs>();

        Debug.LogWarning(transform.name + ": LoadEffectSpawner", gameObject);
    }

    protected virtual AttackPoint GetAttackPoint()
    {
        return this.playerCtrl.Weapons.GetCurrentWeapon().AttackPoint;
    }

    protected abstract void Attacking();
}
