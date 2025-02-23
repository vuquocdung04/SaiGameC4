using Invector.vCharacterController;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class PlayerCtrl : DungMonoBehaviour
{
    [Header("PlayerCtrl")]
    [SerializeField] protected vThirdPersonController vThirdPersonController;
    public vThirdPersonController VThirdPersonController => vThirdPersonController;

    [SerializeField] protected vThirdPersonInput vThirdPersonInput;
    public vThirdPersonInput VThirdPersonInput => vThirdPersonInput;

    [SerializeField] protected CrosshairPointer crosshairPointer;
    public CrosshairPointer CrosshairPointer => crosshairPointer;

    [SerializeField] protected vThirdPersonCamera vThirdPersonCamera;
    public vThirdPersonCamera VThirdPersonCamera => vThirdPersonCamera;

    [SerializeField] protected Rig rig;
    public Rig Rig => rig;

    #region LoadComponents
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadThirdCtrl();
        this.LoadThirdInput();
        this.LoadThirdCamera();
        this.LoadCrossHair();
        this.LoadRig();
    }

    protected virtual void LoadThirdCtrl()
    {
        if (this.vThirdPersonController != null) return;
        this.vThirdPersonController = GetComponent<vThirdPersonController>();

        Debug.LogWarning(transform.name + ": LoadThirdCtrl",gameObject);
    }
    protected virtual void LoadThirdInput()
    {
        if (this.vThirdPersonInput != null) return;
        this.vThirdPersonInput = GetComponent<vThirdPersonInput>();

        Debug.LogWarning(transform.name + ": LoadThirdInput", gameObject);
    }
    protected virtual void LoadCrossHair()
    {
        if (this.crosshairPointer != null) return;
        this.crosshairPointer = GetComponentInChildren<CrosshairPointer>();

        Debug.LogWarning(transform.name + ": LoadCrossHair", gameObject);
    }

    protected virtual void LoadThirdCamera()
    {
        if (this.vThirdPersonCamera != null) return;
        this.vThirdPersonCamera = GameObject.FindAnyObjectByType<vThirdPersonCamera>();

        Debug.LogWarning(transform.name + ": LoadThirdCamera", gameObject);
    }
    protected virtual void LoadRig()
    {
        if (this.rig != null) return;
        this.rig = transform.Find("Model").Find("AimingRig").GetComponent<Rig>();

        Debug.LogWarning(transform.name + ": LoadRig", gameObject);
    }

    #endregion
}
