using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spawner<T> : DungMonoBehaviour where T : PoolObj
{
    [Header("Spawner<T>")]
    [SerializeField] protected int spawnCount = 0;
    [SerializeField] protected PoolHolder poolHolder;
    [SerializeField] protected List<T> isPoolObjs;


    #region LoadComponents
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPoolHolder();
    }

    protected virtual void LoadPoolHolder()
    {
        if (this.poolHolder != null) return;
        this.poolHolder = GetComponentInChildren<PoolHolder>();
        Debug.LogWarning(transform.name + ": LoadPoolHolder", gameObject);
    }

    #endregion



    public virtual Transform Spawn(Transform prefab)
    {
        Transform newObj = Instantiate(prefab);
        return newObj;
    }

    public virtual T Spawn(T prefab)
    {
        T newObj = this.GetObjFromPool(prefab);
        if(newObj == null)
        {
            newObj = Instantiate(prefab);
            this.spawnCount++;
            UpdateName(prefab.transform, newObj.transform);
        }

        if(this.poolHolder != null)
        {
            newObj.transform.parent = this.poolHolder.transform;
        }


        return newObj;
    }
    public virtual T Spawn(T bulletPrefab, Vector3 parentPos)
    {
        T newObj = this.Spawn(bulletPrefab);
        newObj.transform.position = parentPos;
        return newObj;
    }

    public virtual void Despawn(Transform prefab)
    {
        Destroy(prefab.gameObject);
    }
    public virtual void Despawn(T obj)
    {
        if(obj is MonoBehaviour monoBehaviour)
        {
            monoBehaviour.gameObject.SetActive(false);
            this.AddObjToPool(obj);
        }
    }

    protected virtual void UpdateName(Transform prefab, Transform newObj)
    {
        newObj.name = prefab.name +"_"+spawnCount;
    }

    protected virtual void AddObjToPool(T obj)
    {
        this.isPoolObjs.Add(obj);
    }
    protected virtual void RemoveObjFromPool(T obj)
    {
        this.isPoolObjs.Remove(obj);
    }

    // hm lay obj 
    protected virtual T GetObjFromPool(T prefab)
    {
        foreach (T obj in this.isPoolObjs)
        {
            if(prefab.GetName() == obj.GetName())
            {
                this.RemoveObjFromPool(obj);
                return obj;
            }
        }
        return null;
    }
}
