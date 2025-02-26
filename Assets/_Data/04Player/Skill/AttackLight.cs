using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackLight : AttackAbstract
{
    AttackPoint attackPoint;
    string effectName = "Fire1";
    protected override void Attacking()
    {
        if (!InputManager.Instance.IsAttackLight()) return;

        attackPoint = this.GetAttackPoint();

        EffectCtrl effectCtrl = this.spawner.Spawn(this.GetEffect(), attackPoint.transform.position);
        effectCtrl.gameObject.SetActive(true);
        Debug.LogError(this.attackPoint.transform.position);
    }

    protected virtual EffectCtrl GetEffect()
    {
        return this.prefabs.GetByName(this.effectName);
    }
}
