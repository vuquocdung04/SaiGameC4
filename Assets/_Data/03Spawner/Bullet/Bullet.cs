using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Bullet : DungMonoBehaviour
{
    [Header("Bullet")]
    [SerializeField] protected BulletDespawn despawn;
    public BulletDespawn Despawn => despawn;

    [SerializeField] protected float speed = 10f;
    private void Update()
    {
        transform.Translate(speed * Time.deltaTime * Vector3.forward);
    }

    #region LoadComponents
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBulletDespawn();
    }

    protected virtual void LoadBulletDespawn()
    {
        if (this.despawn != null) return;
        this.despawn = transform.GetComponentInChildren<BulletDespawn>();

        Debug.LogWarning(transform.name + ": LoadBulletDespawn", gameObject);
    }
    #endregion


}
