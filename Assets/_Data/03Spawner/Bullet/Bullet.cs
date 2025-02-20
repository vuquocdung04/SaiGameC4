using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Bullet : PoolObj
{

    [SerializeField] protected float speed = 10f;
    private void Update()
    {
        transform.Translate(speed * Time.deltaTime * Vector3.forward);
    }

    


}
