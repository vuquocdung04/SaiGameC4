using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerAiming : PlayerAbstract
{
    protected float closeLookDistance = 1f;
    protected float farLookDistance = 2f;


    /// <summary>
    /// Sau dung observer
    /// </summary>
    private void Update()
    {
        this.Aiming();
    }

    protected virtual void Aiming()
    {
        if (InputManager.Instance.IsRightClick()) this.LookClose();
        else this.LookFar();
    }

    protected virtual void LookClose()
    {
        this.playerCtrl.VThirdPersonCamera.defaultDistance = this.closeLookDistance;
    }

    protected virtual void LookFar()
    {
        this.playerCtrl.VThirdPersonCamera.defaultDistance = this.farLookDistance;
    }
}
