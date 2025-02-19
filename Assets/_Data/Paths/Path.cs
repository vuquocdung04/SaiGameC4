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
            point.LoadNextPoint();
            this.points.Add(point);
        }
        Debug.LogWarning(transform.name + ": LoadPoints", gameObject);
    }
    #endregion

    public virtual Point GetPoint(int pointIndex)
    {
        return this.points[pointIndex];
    }

    public virtual Point GetPoint(string pointName)
    {
        foreach (var point in this.points)
        {
            if(point.name.Equals(pointName)) return point;
        }

        return null;
    }

}
