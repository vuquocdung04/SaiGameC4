using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class BulletSpawner : Spawner<Bullet>
{
    //[Header("BulletSpawner")]
    public virtual Bullet Spawn(Bullet bulletPrefab)
    {
        Bullet newObj = Instantiate(bulletPrefab);

        // bullet sinh ra thi nho spawner cua no la ai
        newObj.Despawn.SetSpawner(this);    
        return newObj;
    }
    public virtual Bullet Spawn(Bullet bulletPrefab, Vector3 parentPos)
    {
        Bullet newObj = Spawn(bulletPrefab);
        newObj.transform.position = parentPos;
        return newObj;
    }

}
