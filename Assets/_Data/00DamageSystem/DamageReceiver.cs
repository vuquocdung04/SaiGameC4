using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageReceiver : DungMonoBehaviour
{
    [Header("DamageReceiever")]
    [SerializeField] protected int maxHp = 10;
    [SerializeField] protected int currentHP = 10;
    [SerializeField] protected bool isDead = false;
    // bat tu
    [SerializeField] protected bool isImmotal = false;

    public virtual int Deduct(int hp)
    {
        if (!this.isImmotal)
            this.currentHP -= hp;
        if (this.IsDead())
            this.OnDead();
        else
            this.OnHit();

        if (this.currentHP < 0) this.currentHP = 0;
        return currentHP;
    }

    protected virtual bool IsDead()
    {
        return this.isDead = this.currentHP <= 0;
    }

    protected virtual void OnDead()
    {
        //TODO: for override
    }

    protected virtual void OnHit()
    {
        //TODO: for override
    }
}
