using Invector.vCharacterController;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : DungMonoBehaviour
{

    [SerializeField] protected List<WeaponAbstract> weapons;

    #region LoadComponents
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadWeapons();
    }

    protected virtual void LoadWeapons()
    {
        if (this.weapons.Count > 0) return;
        foreach(Transform child in transform)
        {
            WeaponAbstract weaponAbstract = child.GetComponent<WeaponAbstract>();
            if(weaponAbstract == null) continue;
            this.weapons.Add(weaponAbstract);
        }   

        Debug.LogWarning(transform.name + ": LoadWeapons", gameObject);
    }

    #endregion

    public virtual WeaponAbstract GetCurrentWeapon()
    {
        return this.weapons[0];
    }
}
