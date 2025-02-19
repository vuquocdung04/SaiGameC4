using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathsManager : Singleton<PathsManager>
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

    // lay Path theo index
    public virtual Path GetPath(int pathIndex)
    {
        return paths[pathIndex];
    }
    // lay Path theo ten
    public virtual Path GetPath(string pathName)
    {
        foreach (var path in this.paths)
        {
            if(path.name.Equals(pathName)) return path;
        }
        return null;
    }
}
