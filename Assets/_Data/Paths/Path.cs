using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Path : DungMonoBehaviour
{
    [Header("Path")]
    [SerializeField] protected List<Point> points;

    #region LoadComponents
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPoints();
    }
    public virtual void LoadPoints()
    {
        if (points.Count > 0) return;
        foreach (Transform child in transform)
        {
            Point point = child.GetComponent<Point>();
            this.points.Add(point);
        }
        Debug.LogWarning(transform.name + ": LoadPoints", gameObject);
    }

    #endregion

}
