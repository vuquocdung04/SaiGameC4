using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]

public class BulletDamageSender : DamageSender
{
    [Header("BulletDamageSender")]
    [SerializeField] protected SphereCollider sphereCollider;
    public SphereCollider SphereCollider => sphereCollider;

    #region LoadComponents
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSphereCollider();
    }
    protected virtual void LoadSphereCollider()
    {
        if (this.sphereCollider != null) return;
        this.sphereCollider = GetComponent<SphereCollider>();
        this.sphereCollider.isTrigger = true;
        this.sphereCollider.radius = 0.05f;
        Debug.LogWarning(transform.name + ": LoadSphereCollider", gameObject);

    }

    #endregion
}
