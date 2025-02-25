using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimingRightHand_target : DungMonoBehaviour
{
    protected override void ResetValues()
    {
        base.ResetValues();
        this.transform.localPosition = new Vector3(0.33f, 0.251f, 0.341f);
        this.transform.localRotation = Quaternion.Euler(9.405f, -117.095f, -69.481f);
    }
}
