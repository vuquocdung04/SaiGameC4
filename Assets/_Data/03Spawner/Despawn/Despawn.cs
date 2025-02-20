using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Despawn<T> : DungMonoBehaviour
{
    [Header("Despawn")]
    [SerializeField] protected T parent;
    [SerializeField] protected Spawner<T> spawner;
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

    #region LoadComponents
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTParent();
    }

    protected virtual void LoadTParent()
    {
        if (this.parent != null) return;
        this.parent = transform.parent.GetComponent<T>();
        Debug.LogWarning(transform.name + ": LoadTParent", gameObject);
    }
    #endregion

    protected virtual void DespawnChecking()
    {
        this.currentTime -= Time.fixedDeltaTime;
        if (this.currentTime > 0) return;

        this.spawner.Despawn(this.parent);
        this.currentTime = this.timeLife;

    }
    public virtual void SetSpawner( Spawner<T> spawner)
    {
        this.spawner = spawner;
    }

}
