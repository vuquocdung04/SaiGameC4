using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolPrefabs<T> : DungMonoBehaviour where T : MonoBehaviour
{
    [Header("PoolPrefabs<T>")]
    [SerializeField] protected List<T> prefabs = new();


    #region LoadComponents
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPrefabs();
    }

    protected virtual void LoadPrefabs()
    {
        if (this.prefabs.Count > 0) return; 
        foreach (Transform child in transform)
        {
            T classPrefabs = child.GetComponent<T>();
            if (classPrefabs) this.prefabs.Add(classPrefabs);
        }

        this.HidePrefabs();
        Debug.LogWarning(transform.name + ": LoadPrefabs", gameObject);
    }

    #endregion

    protected virtual void HidePrefabs()
    {
        foreach (T prefab in this.prefabs)
        {
            prefab.gameObject.SetActive(false);
        }
    }

    //Ramdom enemy
    public virtual T GetRamdom()
    {
        int rand = Random.Range(0, this.prefabs.Count);
        return this.prefabs[rand];
    }

    public virtual T GetByName(string prefabName)
    {
        foreach (T prefab in this.prefabs)
        {
            if (prefab.name != prefabName) continue;
            return prefab;
        }
        return null;
    }
}
