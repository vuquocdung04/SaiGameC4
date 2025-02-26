using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AttackAbstract : DungMonoBehaviour
{
    [Header("Attack Abstract")]
    [SerializeField] protected PlayerCtrl playerCtrl;
    public PlayerCtrl PlayerCtrl => playerCtrl;

    protected void Update()
    {
        this.Attacking();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPlayerCtrl();
    }
    protected virtual void LoadPlayerCtrl()
    {
        if (this.playerCtrl != null) return;
        this.playerCtrl = GetComponentInParent<PlayerCtrl>();

        Debug.LogWarning(transform.name + ": LoadPlayerCtrl", gameObject);
    }

    protected virtual AttackPoint GetAttackPoint()
    {
        return this.playerCtrl.Weapons.GetCurrentWeapon().AttackPoint;
    }

    protected abstract void Attacking();
}
