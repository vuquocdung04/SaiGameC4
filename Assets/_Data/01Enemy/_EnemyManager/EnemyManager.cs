using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : DungMonoBehaviour
{
    [Header("Enemy Manager")]
    [Space(10)]
    [SerializeField] protected EnemySpawner enemySpawner;
    public EnemySpawner EnemySpawner => enemySpawner;

    [SerializeField] protected EnemySpawning enemySpawning;
    public EnemySpawning EnemySpawning => enemySpawning;

    [SerializeField] protected EnemyPrefabs enemyPrefabs;
    public EnemyPrefabs EnemyPrefabs => enemyPrefabs;


    #region LoadComponents
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemySpawner();
        this.LoadEnemySpawning();
        this.LoadEnemyPrefabs();
    }

    protected virtual void LoadEnemySpawner()
    {
        if (this.enemySpawner != null) return;
        this.enemySpawner = GetComponentInChildren<EnemySpawner>();
        Debug.LogWarning(transform.name + ": LoadEnemySpawner", gameObject);
    }
    protected virtual void LoadEnemySpawning()
    {
        if (this.enemySpawning != null) return;
        this.enemySpawning = GetComponentInChildren<EnemySpawning>();
        Debug.LogWarning(transform.name + ": LoadEnemySpawning", gameObject);
    }
    protected virtual void LoadEnemyPrefabs()
    {
        if (this.enemyPrefabs != null) return;
        this.enemyPrefabs = GetComponentInChildren<EnemyPrefabs>();
        Debug.LogWarning(transform.name + ": LoadEnemyPrefabs", gameObject);
    }

    #endregion

}
