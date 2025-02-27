using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class TextAbstract : DungMonoBehaviour
{
    [SerializeField] protected TMP_Text textGoldCount;
    protected string goldCount;


    protected abstract void LoadGoldCount();

    #region LoadComponent

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTextPro();
    }
    protected virtual void LoadTextPro()
    {
        if (this.textGoldCount != null) return;
        this.textGoldCount = GetComponent<TMP_Text>();

        Debug.LogWarning(transform.name + ": LoadTextPro", gameObject);
    }

    #endregion
}
