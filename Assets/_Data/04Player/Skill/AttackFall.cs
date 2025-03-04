using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackFall : AttackAbstract
{
    [Header("Attack Fall")]
    [SerializeField] float numPointsSpawn = 12;
    [SerializeField] float radius = 7f;
    Vector3 posAttack;
    string effectName = "MagicDark";
    string effectCast = "CastDark";
    protected override void Attacking()
    {

        if (!InputManager.Instance.IsAttackFall()) return;

        this.posAttack = this.playerCtrl.CrosshairPointer.transform.position;
        this.posAttack.y += 10f;

        for (int i = 0; i < numPointsSpawn; i++)
        {
            float angle = i * (2 * Mathf.PI / numPointsSpawn);
   
            float offsetX = Mathf.Cos(angle) * radius;
            float offsetZ = Mathf.Sin(angle) * radius;

            Vector3 spawnPos = this.posAttack + new Vector3(offsetX,0,offsetZ);

            EffectCtrl effectCast = this.spawner.Spawn(this.GetCastEffect(), spawnPos);
            effectCast.gameObject.SetActive(true);
            StartCoroutine(this.WaitTime(effectCast.transform.position,effectCast.transform.position));
        }

    }

    IEnumerator WaitTime(Vector3 pos, Vector3 posFall)
    {
        yield return new WaitForSeconds(0.7f);
        EffectCtrl effectCtrl = this.spawner.Spawn(this.GetEffect(), pos);
        EffectFallAbstract effectFall = (EffectFallAbstract)effectCtrl;

        effectFall.FallToTarget.SetTargetFall(posFall);
        effectFall.gameObject.SetActive(true);

    }
    protected virtual EffectCtrl GetCastEffect()
    {
        return this.prefabs.GetByName(this.effectCast);
    }
    protected virtual EffectCtrl GetEffect()
    {
        return this.prefabs.GetByName(this.effectName);
    }
}
