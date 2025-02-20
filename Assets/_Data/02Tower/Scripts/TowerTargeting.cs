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
    [SerializeField] protected EnemyCtrl nearestEnemy;
    public EnemyCtrl NearestEnemy => nearestEnemy;
    [SerializeField] protected List<EnemyCtrl> enemies = new();
    float nearestDistance;
    float enemyDistance;
    private void FixedUpdate()
    {
        this.FindNearest();
    }

    private void OnTriggerEnter(Collider other)
    {
        this.AddEnemy(other);
    }

    private void OnTriggerExit(Collider other)
    {
        this.RemoveEnemy(other);
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

    /// <summary>
    /// Observer FindNearest
    /// </summary>
    protected virtual void FindNearest()
    {
        nearestDistance = Mathf.Infinity;
        foreach (EnemyCtrl enemyCtrl in this.enemies)
        {
            enemyDistance = Vector3.Distance(transform.position, enemyCtrl.transform.position);
            if(enemyDistance < nearestDistance)
            {
                nearestDistance = enemyDistance;
                this.nearestEnemy = enemyCtrl;
            }
        }
    }

    protected virtual void AddEnemy(Collider collider)
    {
        if (collider.name != Const.TOWER_TARGETABLE) return;
        EnemyCtrl enemyCtrl = collider.GetComponentInParent<EnemyCtrl>();
        this.enemies.Add(enemyCtrl);
        Debug.Log("AddEnemy: " + collider.name);
    }

    protected virtual void RemoveEnemy(Collider collider)
    {
        foreach (EnemyCtrl enemyCtrl in this.enemies)
        {
            if (collider.transform.parent == enemyCtrl.transform)
            {
                this.enemies.Remove(enemyCtrl);
                return;
            }
        }
    }

}
