using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallDamageReceiver : DamageReceiver
{
    [Header("Wall Damage Receiver")]
    [SerializeField] protected BoxCollider boxCollider;

    protected override void ResetValues()
    {
        base.ResetValues();
        this.isImmotal = true;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBoxCollider();
    }

    protected virtual void LoadBoxCollider()
    {
        if (this.boxCollider != null) return;
        this.boxCollider = GetComponent<BoxCollider>();
        this.boxCollider.isTrigger = true;

        Debug.LogWarning(transform.name + ": LoadBoxCollider", gameObject);
    }
}
