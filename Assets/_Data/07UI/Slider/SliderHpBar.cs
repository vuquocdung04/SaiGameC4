using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SliderHpBar : SliderAbstract
{
    protected virtual void Start()
    {
        ObserverManager.AddObserver(Const.HpBar, this.UpdateSlider);
    }
    protected virtual void OnDestroy()
    {
        ObserverManager.RemoveObserver(Const.HpBar, this.UpdateSlider);
    }

    protected virtual void UpdateSlider()
    {
        this.sliderHpBar.value = this.GetValue();
    }

    protected abstract float GetValue();
}
