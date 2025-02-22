using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawning : EnemyManagerAbstract
{
    [Header("Enemy Spawning")]
    [Space(10)]
    [SerializeField] protected float spawnSpeed = 1f;

    [SerializeField] protected int maxSpawn = 10;
    [SerializeField] protected List<EnemyCtrl> spawnCtrls = new();


    private void Start()
    {
        InvokeRepeating(nameof(Spawning),spawnSpeed,spawnSpeed);
    }

    /// <summary>
    /// TODO: sau check xem lai
    /// </summary>
    private void FixedUpdate()
    {
        this.RemoveDeadOne();
    }

    protected virtual void Spawning()
    {
        if (this.spawnCtrls.Count >= this.maxSpawn) return;

        EnemyCtrl prefab = this.enemyManager.EnemyPrefabs.GetRamdom();
        EnemyCtrl newEnemy = this.enemyManager.EnemySpawner.Spawn(prefab,transform.position);
        newEnemy.gameObject.SetActive(true);


        this.spawnCtrls.Add(newEnemy);
        Debug.LogError("Spawnnnnn");
    }

    //Remode khoi list khi enemy da chet
    protected virtual void RemoveDeadOne()
    {
        foreach (EnemyCtrl enemyCtrl in this.spawnCtrls)
        {
            if(enemyCtrl.EnemyDamageReceiver.IsDead())
            {
                this.spawnCtrls.Remove(enemyCtrl);
                return;
            }
        }
    }

}
