using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrl : DungMonoBehaviour
{
    [Header("BulletCtrl")]
    [SerializeField] protected Bullet bullet;
    public Bullet Bullet => bullet;



    #region LoadComponents
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBullet();
    }
    protected virtual void LoadBullet()
    {
        if (this.bullet != null) return;
        this.bullet = GetComponentInChildren<Bullet>();
        Debug.LogWarning(transform.name + ": LoadBullet", gameObject);

    }

    #endregion
}
