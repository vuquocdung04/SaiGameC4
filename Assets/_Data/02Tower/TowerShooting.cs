using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TowerShooting : TowerAbstract
{
    [SerializeField] protected EnemyCtrl enemyTarget;
    [SerializeField] protected float rotationSpeed = 2f;
    [SerializeField] protected Bullet bullet;
    Vector3 directionToTarget;
    Vector3 newDirection;
    private void Start()
    {
        //InvokeRepeating(nameof(TargetNearestLoading),2f,2f);
        Invoke(nameof(TargetNearestLoading),1f);
    }
    private void FixedUpdate()
    {
        this.LookingAtTarget();
    }

    //tim Target gan nhat de nhin
    protected virtual void TargetNearestLoading()
    {
        Invoke(nameof(TargetNearestLoading), 1f);

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
        if (this.enemyTarget == null) return;
        //spawner
        this.towerCtrl.BulletSpawner.Spawn(this.towerCtrl.Bullet);
    }

}
