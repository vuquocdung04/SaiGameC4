using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicDarkDamageSender : EffectDamageSender
{
    protected override string GetHitName()
    {
        return "Hit_Dark";
    }
}
