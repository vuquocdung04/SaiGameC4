using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]


public class EffectDamageSender : DamageSender
{
    [Header("BulletDamageSender")]
    [SerializeField] protected SphereCollider sphereCollider;
    public SphereCollider SphereCollider => sphereCollider;

    [SerializeField] protected EffectCtrl effectCtrl;
    public EffectCtrl EffectCtrl => effectCtrl;


    #region LoadComponents
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSphereCollider();
        this.LoadEffectCtrl();
    }
    protected virtual void LoadSphereCollider()
    {
        if (this.sphereCollider != null) return;
        this.sphereCollider = GetComponent<SphereCollider>();
        this.sphereCollider.isTrigger = true;
        this.sphereCollider.radius = 0.05f;
        Debug.LogWarning(transform.name + ": LoadSphereCollider", gameObject);

    }
    protected virtual void LoadEffectCtrl()
    {
        if (this.effectCtrl != null) return;
        this.effectCtrl = GetComponentInParent<EffectCtrl>();
        Debug.LogWarning(transform.name + ": LoadEffectCtrl", gameObject);

    }

    #endregion

    protected override void Send(DamageReceiver damageReceiever)
    {
        base.Send(damageReceiever);
        this.EffectCtrl.DespawnBase.DoDespawn();
        //this.despawn
    }
}
