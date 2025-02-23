using Invector.vCharacterController;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerAbstract : DungMonoBehaviour
{
    [Header("Player Abstract")]
    [SerializeField] protected PlayerCtrl playerCtrl;
    public PlayerCtrl PlayerCtrl => playerCtrl;

    #region LoadComponents
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPlayerCtrl();
    }

    protected virtual void LoadPlayerCtrl()
    {
        if (this.playerCtrl != null) return;
        this.playerCtrl = GetComponentInParent<PlayerCtrl>();

        Debug.LogWarning(transform.name + ": LoadPlayerCtrl", gameObject);
    }
    


    #endregion
}
