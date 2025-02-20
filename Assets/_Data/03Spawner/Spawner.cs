using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spawner : DungMonoBehaviour
{

    public virtual Transform Spawn(Transform prefab)
    {
        Transform newObj = Instantiate(prefab);
        return newObj;
    }
}
