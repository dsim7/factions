﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class ObservedVariable<T>
{
    [SerializeField]
    T _value;
    public T Value { get { return _value; } set { _preChange.Invoke(); _value = value; _onChange.Invoke(); } }

    [NonSerialized]
    UnityEvent _onChange = new UnityEvent();

    public void RegisterAction(UnityAction action)
    {
        _onChange.AddListener(action);
    }

    public void UnregisterAction(UnityAction action)
    {
        _onChange.RemoveListener(action);
    }
    
    public void Invoke()
    {
        _onChange.Invoke();
    }


    [NonSerialized]
    UnityEvent _preChange = new UnityEvent();

    public void RegisterPreAction(UnityAction action)
    {
        _preChange.AddListener(action);
    }

    public void UnregisterPreAction(UnityAction action)
    {
        _preChange.RemoveListener(action);
    }

    public void InvokePre()
    {
        _preChange.Invoke();
    }

}
