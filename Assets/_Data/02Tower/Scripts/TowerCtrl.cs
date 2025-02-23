using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerCtrl : DungMonoBehaviour
{
    [Header("TowerCtrl")]
    [SerializeField] protected Transform model;
    [SerializeField] protected Transform rotator;
    public Transform Rotator => rotator;

    [SerializeField] protected TowerTargeting towerTargeting;
    public TowerTargeting TowerTargeting => towerTargeting;

    [SerializeField] protected BulletSpawner bulletSpawner;
    public BulletSpawner BulletSpawner => bulletSpawner;

    protected string bulletName = "Bullet";
    [SerializeField] protected Bullet bullet;
    public Bullet Bullet => bullet;

    [SerializeField] protected BulletPrefabs bulletPrefabs;
    public BulletPrefabs BulletPrefabs => bulletPrefabs;


    [SerializeField] protected List<FirePoint> firePoints = new();
    public List<FirePoint> FirePoints => firePoints;


    #region LoadComponents
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadModel();
        this.LoadTowerTargeting();
        this.LoadBulletSpawner();
        this.LoadFirePoints();
        this.LoadBulletPrefabs();
    }

    protected virtual void LoadModel()
    {
        if (this.model != null) return;
        this.model = transform.Find("model");
        this.rotator = this.model.Find("Rotator");
        Debug.LogWarning(transform.name + ": LoadModel", gameObject);
    }

    protected virtual void LoadTowerTargeting()
    {
        if (this.towerTargeting != null) return;
        this.towerTargeting = GetComponentInChildren<TowerTargeting>();
        this.towerTargeting.transform.localPosition = new Vector3(0,0.5f,0);
        Debug.LogWarning(transform.name + ": LoadTowerTargeting", gameObject);
    }

    protected virtual void LoadBulletSpawner()
    {
        if (this.bulletSpawner != null) return;
        this.bulletSpawner = FindObjectOfType<BulletSpawner>();
        Debug.LogWarning(transform.name + ": LoadBulletSpawner", gameObject);
    }

    protected virtual void LoadBullet()
    {
        if (this.bullet != null) return;
        this.bullet = this.bulletPrefabs.GetByName(this.bulletName);

        this.HidePrefab();
        Debug.LogWarning(transform.name + ": LoadBullet", gameObject);
    }
    protected virtual void LoadBulletPrefabs()
    {
        if (this.bulletPrefabs != null) return;
        this.bulletPrefabs = GameObject.FindObjectOfType<BulletPrefabs>();
        Debug.LogWarning(transform.name + ": LoadBullet", gameObject);

        this.LoadBullet();
    }

    protected virtual void LoadFirePoints()
    {
        if (this.firePoints.Count > 0) return;
        FirePoint[] points = transform.GetComponentsInChildren<FirePoint>();
        this.firePoints = new List<FirePoint>(points);
        Debug.LogWarning(transform.name + ": LoadFirePoints", gameObject);
    }
    #endregion
    protected virtual void HidePrefab()
    {
        this.bullet.gameObject.SetActive(false);
    }
}
