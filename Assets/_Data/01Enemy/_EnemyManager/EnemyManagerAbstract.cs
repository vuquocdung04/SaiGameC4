using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManagerAbstract : DungMonoBehaviour
{
    [Header("Enemy Manager Abstract")]
    [Space(10)]
    [SerializeField] protected EnemyManager enemyManager;
    public EnemyManager EnemyManager => enemyManager;

    #region LoadComponents
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemyManager();
    }

    protected virtual void LoadEnemyManager()
    {
        if (this.enemyManager != null) return;
        this.enemyManager = GetComponentInParent<EnemyManager>();
        Debug.LogWarning(transform.name + ": LoadEnemyManager", gameObject);
    }

    #endregion

}
