using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHotKey : Singleton<InputHotKey>
{
    [SerializeField] protected bool isToggleInventoryUI = false;
    public bool IsToggleInventoryUI => isToggleInventoryUI;


    private void Update()
    {
        if (this.OpenInventoryUI()) ObserverManager.Notify(Const.HotKeyUI);
    }
    protected virtual bool OpenInventoryUI()
    {
        return this.isToggleInventoryUI = Input.GetKeyUp(KeyCode.I);
    }
}
