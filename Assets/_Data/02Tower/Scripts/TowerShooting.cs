using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TowerShooting : TowerAbstract
{
    [Header("TowerShooting")]
    [SerializeField] protected EnemyCtrl enemyTarget;
    [SerializeField] protected Bullet bullet;
    [Space(10)]
    [SerializeField] protected int currentFirePoint = 0;

    [SerializeField] protected float targetLoadingCountDown = 1f;
    [SerializeField] protected float shootCountDown = 1f;
    [SerializeField] protected float rotationSpeed = 2f;
    Vector3 directionToTarget;
    Vector3 newDirection;
    private void Start()
    {
        InvokeRepeating(nameof(TargetNearestLoading), targetLoadingCountDown, targetLoadingCountDown);
        InvokeRepeating(nameof(this.Shooting),shootCountDown,shootCountDown);
    }
    private void FixedUpdate()
    {
        this.LookingAtTarget();
    }

    //tim Target gan nhat de nhin
    protected virtual void TargetNearestLoading()
    {
        this.enemyTarget = this.towerCtrl.TowerTargeting.NearestEnemy;
    }
    // nhin ve huong target
    protected virtual void LookingAtTarget()
    {
        if (this.enemyTarget == null) return;

        directionToTarget = this.enemyTarget.TowerTargetable.transform.position - this.towerCtrl.Rotator.position;
        newDirection = Vector3.RotateTowards(
                this.towerCtrl.Rotator.forward,
                directionToTarget,
                rotationSpeed * Time.fixedDeltaTime,
                0.0f
            );

        this.towerCtrl.Rotator.rotation = Quaternion.LookRotation(newDirection);
        //this.towerCtrl.Rotator.LookAt(this.enemyTarget.TowerTargetable.transform.position);
    }

    protected virtual void Shooting()
    {
        //neu khong co target => khong ban
        if (this.enemyTarget == null) return;


        //spawner
        FirePoint firePoint = this.GetFirePoint();
        Bullet newBullet = this.towerCtrl.BulletSpawner.Spawn(this.towerCtrl.Bullet, firePoint.transform.position);

        newBullet.gameObject.SetActive(true);
    }
    protected virtual FirePoint GetFirePoint()
    {
        FirePoint firePoint = this.towerCtrl.FirePoints[currentFirePoint];
        this.currentFirePoint++;
        if (this.currentFirePoint == this.towerCtrl.FirePoints.Count) this.currentFirePoint = 0;

        return firePoint;
    }
}
