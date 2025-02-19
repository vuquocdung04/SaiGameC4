using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMoving : MonoBehaviour
{
    [SerializeField] protected GameObject target;
    [SerializeField] protected NavMeshAgent navAgent;

    private void Start()
    {
    }

    private void FixedUpdate()
    {
        navAgent.SetDestination(target.transform.position);
    }

}
