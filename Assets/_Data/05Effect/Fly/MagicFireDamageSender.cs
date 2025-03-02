using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicFireDamageSender : EffectDamageSender
{
    protected override string GetHitName()
    {
        return "Hit_Fire";
    }
}
