using UnityEngine;
using System.Collections;
using System;

public class UISushi : MonoBehaviour 
{
    public Action<int> GotDestroyed = (int Type) => { };
    public int Type;

    void OnDestroy()
    {
        GotDestroyed(Type);
    }
}
