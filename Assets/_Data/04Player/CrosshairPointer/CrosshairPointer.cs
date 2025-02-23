using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrosshairPointer : DungMonoBehaviour
{
    [Header("CrosshairPointer")]
    [SerializeField] protected float maxDistance = 100f;
    [SerializeField] protected LayerMask layerMask = -1;

    Vector3 screenCenter;
    Ray ray;

    private void Update()
    {
        this.Pointing();
    }

    protected virtual void Pointing()
    {
        screenCenter = new Vector3(Screen.width/2f, Screen.height/2f,0f);
        ray = Camera.main.ScreenPointToRay(screenCenter);

        if (Physics.Raycast(ray,out RaycastHit hit, maxDistance, layerMask))
        {
            transform.position = hit.point;
        }
    }

}
