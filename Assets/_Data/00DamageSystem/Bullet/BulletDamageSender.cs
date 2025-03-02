using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]

public class BulletDamageSender : DamageSender
{
    [Header("BulletDamageSender")]
    [SerializeField] protected SphereCollider sphereCollider;
    public SphereCollider SphereCollider => sphereCollider;

    [SerializeField] protected BulletCtrl bulletCtrl;
    public BulletCtrl BulletCtrl => bulletCtrl;


    #region LoadComponents
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSphereCollider();
        this.LoadBulletCtrl();
    }
    protected virtual void LoadSphereCollider()
    {
        if (this.sphereCollider != null) return;
        this.sphereCollider = GetComponent<SphereCollider>();
        this.sphereCollider.isTrigger = true;
        this.sphereCollider.radius = 0.05f;
        Debug.LogWarning(transform.name + ": LoadSphereCollider", gameObject);

    }
    protected virtual void LoadBulletCtrl()
    {
        if (this.bulletCtrl != null) return;
        this.bulletCtrl = GetComponentInParent<BulletCtrl>();
        Debug.LogWarning(transform.name + ": LoadBulletCtrl", gameObject);

    }

    #endregion

    protected override void Send(DamageReceiver damageReceiever)
    {
        base.Send(damageReceiever);
        this.bulletCtrl.Bullet.DespawnBase.DoDespawn();
        //this.despawn
    }
}
