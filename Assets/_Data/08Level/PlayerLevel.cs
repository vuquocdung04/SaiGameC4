using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLevel : LevelByItem
{
    private void Start()
    {
        ObserverManager.AddObserver(Const.PlayerLevel,this.Leveling);
    }
    private void OnDestroy()
    {
        ObserverManager.RemoveObserver(Const.PlayerLevel,this.Leveling);
    }
}
