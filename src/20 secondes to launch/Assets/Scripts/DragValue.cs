﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragValue : MonoBehaviour
{
 
    public float value;
    public float min;
    public float max;
    public float deltaByDistance;
    public bool resetOnRelease = false;
    public float resetValue = 0;

    [SerializeField] private UnityEventFloat onValue;

    private float lastMousePos;

    private void OnValidate()
    {
        if (min > max)
            min = max;
    }

    private void OnMouseDown()
    {
        lastMousePos = Input.mousePosition.x;
    }

    private void OnMouseUp()
    {
        if (resetOnRelease)
            SetValue(resetValue);
    }

    private void OnMouseDrag()
    {
        var diff = Input.mousePosition.x - lastMousePos;
        value += diff * deltaByDistance;
        lastMousePos = Input.mousePosition.x;
        SetValue(value);
    }

    private void SetValue(float value)
    {
        this.value = Mathf.Clamp(value, min, max);
        onValue.Invoke(value);
    }
}
