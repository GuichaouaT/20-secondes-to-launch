using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragValue : MonoBehaviour
{
    public float value;
    public float min;
    public float max;
    public float deltaByDistance;

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

    private void OnMouseDrag()
    {
        var diff = Input.mousePosition.x - lastMousePos;
        value += diff * deltaByDistance;
        value = Mathf.Clamp(value, min, max);
        lastMousePos = Input.mousePosition.x;
        onValue.Invoke(value);
    }
}
