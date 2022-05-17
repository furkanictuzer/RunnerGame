using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapToStartController : MonoSingleton<TapToStartController>
{
    private Action _tapToStart;

    public void OnTapToStart()
    {
        _tapToStart?.Invoke();
    }
    
    public void AddMethodTapToStart(params Action[] methods)
    {
        foreach (var method in methods)
            _tapToStart += method;
    }
}
