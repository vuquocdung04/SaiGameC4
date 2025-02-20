using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DungMonoBehaviour : MonoBehaviour
{
    protected virtual void Awake()
    {
        this.LoadComponents();
    }
    protected virtual void Reset()
    {
        this.LoadComponents();
        this.ResetValues();
    }
    protected virtual void LoadComponents()
    {
        //TODO: for override
    }

    protected virtual void ResetValues()
    {

    }


}
