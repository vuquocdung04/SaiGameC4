using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallToTarget : MonoBehaviour
{
    protected Vector3 targetPos;
    [SerializeField] protected float speed = 20f;


    private void Update()
    {
        this.Falling();
    }
    public virtual void SetTargetFall(Vector3 target)
    {
        this.targetPos = target;
        transform.parent.LookAt(target);
    }

    protected virtual void Falling()
    {
        if (this.targetPos == null) return;
        transform.parent.Translate(speed * Time.deltaTime * Vector3.down);
    }
}
