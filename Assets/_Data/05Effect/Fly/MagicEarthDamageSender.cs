using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicEarthDamageSender : EffectDamageSender
{
    protected override string GetHitName()
    {
        return "Hit_Earth";
    }
}
