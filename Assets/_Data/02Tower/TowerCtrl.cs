using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerCtrl : DungMonoBehaviour
{
    [Header("TowerCtrl")]
    [SerializeField] protected Transform model;
    [SerializeField] protected Transform rotator;
    public Transform Rotator => rotator;
    #region LoadComponents
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadModel();
    }

    protected virtual void LoadModel()
    {
        if (this.model != null) return;
        this.model = transform.Find("model");
        this.rotator = this.model.Find("Rotator");
        Debug.LogWarning(transform.name + ": LoadModel", gameObject);
    }

    #endregion
}
