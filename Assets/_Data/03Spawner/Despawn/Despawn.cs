using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Despawn : DungMonoBehaviour
{
    [Header("Despawn")]
    [SerializeField] protected Spawner spawner;
    /// <summary>
    /// Note: Oserver -> theo distance thay vi timer
    /// </summary>
    ///
    [Space(10)]
    [SerializeField] protected float timeLife = 7f;
    [SerializeField] protected float currentTime = 7f;

    private void FixedUpdate()
    {
        this.DespawnChecking();
    }

    protected virtual void DespawnChecking()
    {
        this.currentTime -= Time.fixedDeltaTime;
        if (this.currentTime > 0) return;

        this.spawner.Despawn(transform.parent);
        this.currentTime = this.timeLife;

    }
    public virtual void SetSpawner( Spawner spawner)
    {
        this.spawner = spawner;
    }

}
