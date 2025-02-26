using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackLight : AttackAbstract
{
    AttackPoint attackPoint;
    protected override void Attacking()
    {
        if (!InputManager.Instance.IsAttackLight()) return;

        attackPoint = this.GetAttackPoint();
        Debug.LogError(this.attackPoint.transform.position);
    }
}
