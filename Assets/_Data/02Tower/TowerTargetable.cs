using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(SphereCollider))]
public class TowerTargetable : DungMonoBehaviour
{
    [Header("TowerTargetable")]
    [SerializeField] protected SphereCollider _sphereCollider;

    #region LoadComponents
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSphereCollider();
    }

    protected virtual void LoadSphereCollider()
    {
        if (this._sphereCollider != null) return;
        this._sphereCollider = GetComponent<SphereCollider>();
        this._sphereCollider.radius = 0.5f;
        this._sphereCollider.isTrigger = true;

        Debug.LogWarning(transform.name + ": LoadSphereCollider", gameObject);
    }

    #endregion

}
