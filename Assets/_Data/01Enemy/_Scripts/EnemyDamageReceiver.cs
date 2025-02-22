using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(CapsuleCollider))]

public class EnemyDamageReceiver : DamageReceiver
{
    [Header("BulletDamageSender")]
    [SerializeField] protected CapsuleCollider capsuleCollider;
    public CapsuleCollider CapsuleCollider => capsuleCollider;

    #region LoadComponents
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCapsuleCollider();
    }
    protected virtual void LoadCapsuleCollider()
    {
        if (this.capsuleCollider != null) return;
        this.capsuleCollider = GetComponent<CapsuleCollider>();
        this.capsuleCollider.isTrigger = true;
        this.capsuleCollider.radius = 0.3f;
        this.capsuleCollider.height = 2f;
        this.capsuleCollider.center = new Vector3(0,1,0);
        Debug.LogWarning(transform.name + ": LoadCapsuleCollider", gameObject);

    }

    #endregion
}
