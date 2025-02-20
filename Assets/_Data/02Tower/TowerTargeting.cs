using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(SphereCollider))]

public class TowerTargeting : DungMonoBehaviour
{
    [SerializeField] protected Rigidbody _rigidbody;
    [SerializeField] protected SphereCollider _sphereCollider;
    [SerializeField] protected EnemyCtrl nearest;
    [SerializeField] protected List<EnemyCtrl> enemies = new();

    private void FixedUpdate()
    {
        this.FindNearest();
    }

    #region LoadComponents
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSphereCollider();
        this.LoadRigidbody();
    }

    protected virtual void LoadSphereCollider()
    {
        if (this._sphereCollider != null) return;
        this._sphereCollider = GetComponent<SphereCollider>();
        this._sphereCollider.isTrigger = true;
        this._sphereCollider.radius = 7;

        Debug.LogWarning(transform.name + ": LoadSphereCollider", gameObject);
    }

    protected virtual void LoadRigidbody()
    {
        if (this._rigidbody != null) return;
        this._rigidbody = GetComponent<Rigidbody>();
        this._rigidbody.useGravity = false;
        Debug.LogWarning(transform.name + ": LoadRigidbody", gameObject);
    }
    #endregion


    protected virtual void FindNearest()
    {

    }

}
