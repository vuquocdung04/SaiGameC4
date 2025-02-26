using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : Singleton<InputManager>
{
    protected bool isAiming = false;
    protected bool isAttackLight = false;

    private void Update()
    {
        this.CheckAiming();
        this.CheckAttackLight();
    }

    protected virtual void CheckAttackLight()
    {
        this.isAttackLight = Input.GetMouseButtonUp(0);
    }
    protected virtual void CheckAiming()
    {
        this.isAiming = Input.GetMouseButton(1);
    }

    public virtual bool IsAiming()
    {
        return this.isAiming;
    }

    public virtual bool IsAttackLight()
    {
        return this.isAttackLight;
    }
}
