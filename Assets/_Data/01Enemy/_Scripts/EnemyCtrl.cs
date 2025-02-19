using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyCtrl : DungMonoBehaviour
{
    [Header("EnemyCtrl")]
    [SerializeField] protected NavMeshAgent agent;
    public NavMeshAgent Agent => agent;

    [SerializeField] protected Transform model;

    #region LoadComponents
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadNavMeshAgent();
        this.LoadModel();
    }

    protected virtual void LoadNavMeshAgent()
    {
        if (this.agent != null) return;
        this.agent = GetComponent<NavMeshAgent>();
        this.agent.angularSpeed = 200;
        this.agent.speed = 2;
        this.agent.acceleration = 150;  
        Debug.LogWarning(transform.name + ": LoadNavMeshAgent", gameObject);
    }

    protected virtual void LoadModel()
    {
        if (this.model != null) return;
        this.model = transform.Find("model");

        Debug.LogWarning(transform.name + ": LoadModel", gameObject);
    }

    #endregion
}
