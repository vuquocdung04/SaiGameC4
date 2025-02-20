using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spawner<T> : DungMonoBehaviour where T : PoolObj
{
    [SerializeField] protected List<T> isPoolObjs;
    public virtual Transform Spawn(Transform prefab)
    {
        Transform newObj = Instantiate(prefab);
        return newObj;
    }

    public virtual T Spawn(T bulletPrefab)
    {
        T newObj = Instantiate(bulletPrefab);

        // bullet sinh ra thi nho spawner cua no la ai
        //newObj.Despawn.SetSpawner(this);
        return newObj;
    }
    public virtual T Spawn(T bulletPrefab, Vector3 parentPos)
    {
        T newObj = Spawn(bulletPrefab);
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

    protected virtual void AddObjToPool(T obj)
    {
        this.isPoolObjs.Add(obj);
    }
}
