using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageReceiver : DungMonoBehaviour
{
    [Header("DamageReceiever")]
    [SerializeField] protected int maxHp = 10;
    [SerializeField] protected int currentHP = 10;
    [SerializeField] protected bool isDead = false;


    public virtual int Deduct(int hp)
    {
        this.currentHP -= hp;
        this.IsDead();

        if (this.currentHP < 0) this.currentHP = 0;
        return currentHP;
    }

    protected virtual bool IsDead()
    {
        return this.isDead = this.currentHP <= 0;
    }
}
