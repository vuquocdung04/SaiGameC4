using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHeavy : AttackAbstract
{
    AttackPoint attackPoint;
    string effectName = "Fire2";
    protected override void Attacking()
    {
        if (!InputManager.Instance.IsAttackHeavy()) return;

        attackPoint = this.GetAttackPoint();

        EffectCtrl effectCtrl = this.spawner.Spawn(this.GetEffect(), attackPoint.transform.position);
        EffectFlyAbstract effectFly = (EffectFlyAbstract)effectCtrl;
        effectFly.FlyToTarget.SetTarget(this.playerCtrl.CrosshairPointer.transform);

        effectCtrl.gameObject.SetActive(true);

        Debug.LogError(this.attackPoint.transform.position);
    }

    protected virtual EffectCtrl GetEffect()
    {
        return this.prefabs.GetByName(this.effectName);
    }
}
