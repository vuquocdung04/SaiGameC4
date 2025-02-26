using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObserverManager
{
    static Dictionary<string, List<Action>> listeners = new();

    public static void AddObserver(string name, Action callback)
    {
        if (!listeners.ContainsKey(name))
            listeners.Add(name, new List<Action>());

        listeners[name].Add(callback);
    }

    public static void RemoveObserver(string name, Action callback)
    {
        if (!listeners.ContainsKey(name)) return;
        listeners[name].Remove(callback);
    }

    public static void Notify(string name)
    {
        if (!listeners.ContainsKey(name)) return;

        foreach (Action child in listeners[name])
        {
            child?.Invoke();
        }
    }
}
