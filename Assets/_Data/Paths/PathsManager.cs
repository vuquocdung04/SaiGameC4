using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathsManager : DungMonoBehaviour
{
    [Header("PathsManager")]
    [SerializeField] protected List<Path> paths = new();

    #region LoadComponents
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPaths();
    }
    protected virtual void LoadPaths()
    {
        if (paths.Count > 0) return;
        foreach (Transform child in transform)
        {
            Path path = child.GetComponent<Path>();
            path.LoadPoints();
            this.paths.Add(path);
        }
        Debug.LogWarning(transform.name + ": LoadPaths", gameObject);

    }
    #endregion
}
