using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimingRightHand_hint : DungMonoBehaviour
{

    protected override void ResetValues()
    {
        base.ResetValues();
        this.transform.localPosition = new Vector3(0.478f, -0.023f, 0.001f);
        this.transform.localRotation = Quaternion.Euler(0, 0, 0);
    }
}
