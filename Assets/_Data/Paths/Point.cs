using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Point : DungMonoBehaviour
{
    [SerializeField] protected Point nextPoint;
    public Point NextPoint => nextPoint;
    #region LoadComponents
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadNextPoint();
    }
    public virtual void LoadNextPoint()
    {
        if (this.nextPoint != null) return;
        int siblingIndex = transform.GetSiblingIndex();

        if(siblingIndex + 1 < transform.parent.childCount)
        {
            Transform nextSibling = transform.parent.GetChild(siblingIndex + 1);
            this.nextPoint = nextSibling.GetComponent<Point>();
        }

        Debug.LogWarning(transform.name + ": LoadNextPoint", gameObject);
    }

    #endregion
}
