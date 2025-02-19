using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMoving : DungMonoBehaviour
{
    [Header("EnemyMoving")]
    [SerializeField] protected EnemyCtrl enemyCtrl;
    [SerializeField] protected string pathName = "path_1";
    [SerializeField] protected Path enemyPath;
    [SerializeField] protected Point currentPoint;
    [SerializeField] protected float pointDistance = Mathf.Infinity;
    [SerializeField] protected float stopDistance = 1f;

    [SerializeField] protected bool isFinish;
    //[SerializeField] protected int pathIndex = 0;

    private void Start()
    {
        this.LoadEnemyPath();
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
    }

    protected virtual void LoadEnemyCtrl()
    {
        if (this.enemyCtrl != null) return;
        this.enemyCtrl = GetComponentInParent<EnemyCtrl>();
        Debug.LogWarning(transform.name + ": LoadEnemyCtrl", gameObject);
    }


    #endregion

    protected virtual void Moving()
    {
        this.FindNextPoint();

        if (this.currentPoint == null || this.isFinish)
        {
            this.enemyCtrl.Agent.isStopped = true;
            return;
        }
            
        this.enemyCtrl.Agent.SetDestination(this.currentPoint.transform.position);
    }

    protected virtual void FindNextPoint()
    {
        if (this.currentPoint == null) this.currentPoint = this.enemyPath.GetPoint(0);

        this.pointDistance = Vector3.Distance(transform.position, currentPoint.transform.position);

        if(this.pointDistance < this.stopDistance)
        {
            this.currentPoint = this.currentPoint.NextPoint;
        }
    }

    protected virtual void LoadEnemyPath()
    {
        if (this.enemyPath != null) return;
        this.enemyPath = PathsManager.Instance.GetPath(this.pathName);
        Debug.LogWarning(transform.name + ": LoadEnemyPath", gameObject);
    }

}
