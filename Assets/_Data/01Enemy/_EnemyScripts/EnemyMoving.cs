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

    [Header("Bool")]

    //vd: sau co skill giu chan enemy thi no se khong di chuyen duoc
    [SerializeField] protected bool canMove = true;
    // anim
    [SerializeField] protected bool isMoving = false;
    // check toi diem cuoi
    [SerializeField] protected bool isFinish = false;
    //[SerializeField] protected int pathIndex = 0;

    private void Start()
    {
        this.LoadEnemyPath();
    }

    private void FixedUpdate()
    {
        this.Moving();
        this.CheckMoving();
    }

    protected virtual void OnEnable()
    {
        this.OnReborn();
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

    protected virtual void LoadEnemyPath()
    {
        if (this.enemyPath != null) return;
        this.enemyPath = PathsManager.Instance.GetPath(this.pathName);
        Debug.LogWarning(transform.name + ": LoadEnemyPath", gameObject);
    }

    #endregion

    protected virtual void Moving()
    {
        if(!this.canMove)
        {
            this.enemyCtrl.Agent.isStopped = true;
            return;
        }

        if (this.enemyCtrl.EnemyDamageReceiver.IsDead())
        {
            this.enemyCtrl.Agent.isStopped = true;
            return;
        }

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

    /// <summary>
    /// TODO: Observer CheckMoving()
    /// </summary>
    protected virtual void CheckMoving()
    {
        if(this.enemyCtrl.Agent.velocity.magnitude > 0.1f) this.isMoving = true;
        else this.isMoving = false;

        this.enemyCtrl.Animator.SetBool(Const.ISMOVING, isMoving);
    }

    protected virtual void OnReborn()
    {
        this.isFinish = false;
        this.currentPoint = null;
    }

}
