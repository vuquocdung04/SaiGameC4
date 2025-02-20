using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerCtrl : DungMonoBehaviour
{
    [Header("TowerCtrl")]
    [SerializeField] protected Transform model;

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
        Debug.LogWarning(transform.name + ": LoadModel", gameObject);
    }

    #endregion
}
