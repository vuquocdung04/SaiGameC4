using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerAiming : PlayerAbstract
{
    protected float closeLookDistance = 1f;
    protected float farLookDistance = 2.5f;


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

        CrosshairPointer crosshairPointer = this.playerCtrl.CrosshairPointer;
        this.playerCtrl.VThirdPersonController.RotateToPosition(crosshairPointer.transform.position);
        this.playerCtrl.VThirdPersonController.isSprinting = false;

        this.playerCtrl.Rig.weight = 1;
    }

    protected virtual void LookFar()
    {
        this.playerCtrl.VThirdPersonCamera.defaultDistance = this.farLookDistance;
        this.playerCtrl.Rig.weight = 0;
    }
}
