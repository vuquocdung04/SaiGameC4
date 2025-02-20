using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spawner : DungMonoBehaviour
{
    public virtual Bullet Spawn(Bullet bulletPrefab)
    {
        Bullet newObj = Instantiate(bulletPrefab);
        return newObj;
    }
    public virtual Transform Spawn(Transform prefab)
    {
        Transform newObj = Instantiate(prefab);
        return newObj;
    }
}
