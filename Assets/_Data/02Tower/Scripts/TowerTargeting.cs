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
    //tim enemy gan nhat de ban
    [SerializeField] protected EnemyCtrl nearestEnemy;
    public EnemyCtrl NearestEnemy => nearestEnemy;
    [SerializeField] protected List<EnemyCtrl> enemies = new();
    float nearestDistance;
    float enemyDistance;

    /// <summary>
    /// 
    /// </summary>
    private void FixedUpdate()
    {
        this.FindNearest();
        this.RemoveDeadEnemy();
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
        if (this.enemies.Count == 0)
        {
            this.nearestEnemy = null;
            return;
        }

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

        // neu enemy chet roi thi return
        if (enemyCtrl.EnemyDamageReceiver.IsDead()) return;

        this.enemies.Add(enemyCtrl);
        Debug.Log("AddEnemy: " + collider.name);
    }

    // remove nay remove enemy khi da ra khoi vung tan cong
    protected virtual void RemoveEnemy(Collider collider)
    {
        foreach (EnemyCtrl enemyCtrl in this.enemies)
        {
            // neu enemy == enemyda add trong list ma ra khoi vung => tien hanh remove
            if (collider.transform.parent == enemyCtrl.transform)
            {
                this.enemies.Remove(enemyCtrl);
                return;
            }
        }
    }
    // remove nay remove enemy khoi danh sach khi da chet
    protected virtual void RemoveDeadEnemy()
    {
        foreach (EnemyCtrl enemyCtrl in this.enemies)
        {
            if(enemyCtrl.EnemyDamageReceiver.IsDead())
            {
                this.enemies.Remove(enemyCtrl);
                return;
            }
        }
    }

}
