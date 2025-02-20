using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class BulletSpawner : Spawner
{
    //[Header("BulletSpawner")]
    public virtual Bullet Spawn(Bullet bulletPrefab)
    {
        Bullet newObj = Instantiate(bulletPrefab);
        return newObj;
    }
    public virtual Bullet Spawn(Bullet bulletPrefab, Vector3 parentPos)
    {
        Bullet newObj = Spawn(bulletPrefab);
        newObj.transform.position = parentPos;
        return newObj;
    }

}
