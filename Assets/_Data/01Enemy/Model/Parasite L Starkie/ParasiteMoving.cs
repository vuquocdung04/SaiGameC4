using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParasiteMoving : EnemyMoving
{
    protected override void ResetValues()
    {
        base.ResetValues();
        this.pathName = "path_0";
    }
}
