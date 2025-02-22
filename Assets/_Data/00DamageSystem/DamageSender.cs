using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class DamageSender : DungMonoBehaviour
{
    [Header("DamageSender")]
    [SerializeField] protected Rigidbody _rigidbody;
    public Rigidbody Rigidbody => _rigidbody;

    [SerializeField] protected int damage = 1;

    public virtual void OnTriggerEnter(Collider other)
    {
        DamageReceiver damageReceiver = other.GetComponent<DamageReceiver>();
        if (damageReceiver == null) return;
        this.Send(damageReceiver);

        Debug.LogError("check");
    }
    #region LoadComponents
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadRigidbody();
    }
    protected virtual void LoadRigidbody()
    {
        if (this._rigidbody != null) return;
        this._rigidbody = GetComponent<Rigidbody>();
        this._rigidbody.useGravity = false;
        Debug.LogWarning(transform.name + ": LoadSphereCollider", gameObject);

    }

    #endregion


    protected virtual void Send(DamageReceiver damageReceiever)
    {
        damageReceiever.Deduct(this.damage);

    }
}
