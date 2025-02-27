using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ItemDropCtrl : PoolObj
{
    [Header("ItemDropCtrl")]
    [SerializeField] protected Rigidbody _rigi;
    public Rigidbody Rigi => _rigi;
    public override string GetName()
    {
        return "ItemDrop";
    }

    #region LoadComponent
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadRigidbody();
    }
    protected virtual void LoadRigidbody()
    {
        if (this._rigi != null) return;
        this._rigi = GetComponent<Rigidbody>();

        Debug.LogWarning(transform.name + ": LoadRigidbody", gameObject);
    }

    #endregion
}
