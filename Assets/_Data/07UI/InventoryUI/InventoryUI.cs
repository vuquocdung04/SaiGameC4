using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] protected bool isShow = false;
    bool IsShow => isShow;
    private void Start()
    {
        this.Hide();
    }

    protected virtual void Hide()
    {
        gameObject.SetActive(false);
        this.isShow = false;
    }

    protected virtual void Show()
    {
        gameObject.SetActive(true);
        this.isShow = true;
    }
}
