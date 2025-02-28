using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class ItemPicker : DungMonoBehaviour
{
    [Header("Item Picker")]
    [SerializeField] protected SphereCollider sphereCollider;
    public SphereCollider SphereCollider => sphereCollider;


    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent == null) return;

        ItemDropCtrl itemDropCtrl = other.transform.parent.GetComponent<ItemDropCtrl>();
        if (itemDropCtrl == null) return;

        itemDropCtrl.DespawnBase.DoDespawn();
    }

    #region LoadComponent
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCollider();
    }
    protected virtual void LoadCollider()
    {
        if (this.sphereCollider != null) return;
        this.sphereCollider = GetComponent<SphereCollider>();
        this.sphereCollider.isTrigger = true;
        this.sphereCollider.radius = 1f;

        Debug.LogWarning(transform.name + ": LoadCollider", gameObject);
    }

    #endregion
}
