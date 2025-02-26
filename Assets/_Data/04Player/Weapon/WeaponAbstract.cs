using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponAbstract : DungMonoBehaviour
{
    [Header("Weapon Abstract")]
    [SerializeField] protected AttackPoint attackPoint;
    public AttackPoint AttackPoint => attackPoint;


    #region LoadComponents
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadAttackPoint();
    }

    protected virtual void LoadAttackPoint()
    {
        if (this.attackPoint != null) return;
        this.attackPoint = GetComponentInChildren<AttackPoint>();

        Debug.LogWarning(transform.name + ": LoadAttackPoint", gameObject);
    }

    #endregion
}
