﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapFloat : MonoBehaviour
{
#pragma warning disable CS0649
    public float minIn;
    public float maxIn;
    public float minOut;
    public float maxOut;

    [SerializeField] private UnityEventFloat onValue;
#pragma warning restore CS0649

    private void OnValidate()
    {
        if (minIn > maxIn)
            minIn = maxIn;
        if (minOut > maxOut)
            minOut = maxOut;
    }

    public void Set(float value)
    {
        var v = (((value - minIn) / (maxIn - minIn)) * (maxOut - minOut)) + minOut;
        onValue.Invoke(v);
    }
}
