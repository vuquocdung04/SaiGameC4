using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CapsuleCollider))]


public class EffectDamageSender : DamageSender
{
    [Header("BulletDamageSender")]
    [SerializeField] protected CapsuleCollider capsunCollider;
    public CapsuleCollider CapsunCollider => capsunCollider;

    [SerializeField] protected EffectCtrl effectCtrl;
    public EffectCtrl EffectCtrl => effectCtrl;

    [SerializeField] protected EffectHitSpawner effectHitSpawner;
    public EffectHitSpawner EffectHitSpawner => effectHitSpawner;

    [SerializeField] protected EffectHitPrefab effectHitPrefab;

    #region LoadComponents
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSphereCollider();
        this.LoadEffectCtrl();
    }
    protected virtual void LoadSphereCollider()
    {
        if (this.capsunCollider != null) return;
        this.capsunCollider = GetComponent<CapsuleCollider>();
        this.capsunCollider.isTrigger = true;
        this.capsunCollider.radius = 0.2f;
        this.capsunCollider.height = 0.75f;
        this.capsunCollider.direction = 0;
        this.capsunCollider.center = new Vector3(-0.5f,0,0);

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
        EffectHitCtrl fireHitCtrl = this.effectHitSpawner.Spawn(this.effectHitPrefab.GetByName("Magic_Hit"), this.transform.parent.position);
        fireHitCtrl.gameObject.SetActive(true);
        //this.despawn

    }

}
