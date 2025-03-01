using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class SliderAbstract : DungMonoBehaviour
{
    [Header("Slider Abstract")]
    [SerializeField] protected Slider sliderHpBar;

    #region LoadComponent

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadHpBar();
    }
    protected virtual void LoadHpBar()
    {
        if (this.sliderHpBar != null) return;
        this.sliderHpBar = GetComponent<Slider>();

        Debug.LogWarning(transform.name + ": LoadHpBar", gameObject);
    }

    #endregion
}
