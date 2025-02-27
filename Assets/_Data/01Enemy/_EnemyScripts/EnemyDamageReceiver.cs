using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(CapsuleCollider))]

public class EnemyDamageReceiver : DamageReceiver
{
    [Header("BulletDamageSender")]
    [SerializeField] protected CapsuleCollider capsuleCollider;
    public CapsuleCollider CapsuleCollider => capsuleCollider;

    [SerializeField] protected EnemyCtrl enemyCtrl;
    public EnemyCtrl EnemyCtrl => enemyCtrl;

    #region LoadComponents
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCapsuleCollider();
        this.LoadEnemyCtrl();
    }
    protected virtual void LoadCapsuleCollider()
    {
        if (this.capsuleCollider != null) return;
        this.capsuleCollider = GetComponent<CapsuleCollider>();
        this.capsuleCollider.isTrigger = true;
        this.capsuleCollider.radius = 0.3f;
        this.capsuleCollider.height = 2f;
        this.capsuleCollider.center = new Vector3(0,1,0);
        Debug.LogWarning(transform.name + ": LoadCapsuleCollider", gameObject);

    }
    protected virtual void LoadEnemyCtrl()
    {
        if (this.enemyCtrl != null) return;
        this.enemyCtrl = GetComponentInParent<EnemyCtrl>();
        Debug.LogWarning(transform.name + ": LoadEnemyCtrl", gameObject);

    }


    #endregion

    protected override void OnDead()
    {
        base.OnDead();
        this.enemyCtrl.Animator.SetBool(Const.ISDEAD,this.isDead);
        this.capsuleCollider.enabled = false;

        this.DropOnDead();
        Invoke(nameof(this.DisAppear),5f);
    }

    protected override void OnHit()
    {
        base.OnHit();
        this.enemyCtrl.Animator.SetTrigger(Const.ISHIT);
    }

    protected virtual void DisAppear()
    {
        this.enemyCtrl.DespawnBase.DoDespawn();
    }

    protected override void OnReborn()
    {
        base.OnReborn();
        this.capsuleCollider.enabled = true;
    }

    //roi do khi chet
    protected virtual void DropOnDead()
    {
        ItemDropManager.Instance.Drop(ItemCode.Gold, 1, transform.position);
    }
}
