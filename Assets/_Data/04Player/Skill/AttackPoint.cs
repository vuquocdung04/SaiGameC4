using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPoint : DungMonoBehaviour
{
    protected override void ResetValues()
    {
        base.ResetValues();
        this.transform.localPosition = new Vector3(0.05f,0.5f,0f);
    }
}
