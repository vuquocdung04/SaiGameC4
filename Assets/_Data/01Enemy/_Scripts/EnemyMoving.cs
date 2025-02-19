using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMoving : DungMonoBehaviour
{
    [Header("EnemyMoving")]
    [SerializeField] protected EnemyCtrl enemyCtrl;
    [Space(10)]
    [SerializeField] protected GameObject target;

    private void Start()
    {
    }

    private void FixedUpdate()
    {
        this.Moving();
    }


    #region LoadComponents
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemyCtrl();
        this.LoadTarget();
    }

    protected virtual void LoadEnemyCtrl()
    {
        if (this.enemyCtrl != null) return;
        this.enemyCtrl = GetComponentInParent<EnemyCtrl>();
        Debug.LogWarning(transform.name + ": LoadEnemyCtrl", gameObject);
    }
    protected virtual void LoadTarget()
    {
        if (this.target != null) return;
        this.target = GameObject.Find("TargetMoving");
        Debug.LogWarning(transform.name + ": LoadTarget", gameObject);
    }


    #endregion

    protected virtual void Moving()
    {
        enemyCtrl.Agent.SetDestination(target.transform.position);
    }

}
