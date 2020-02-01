using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragValue : MonoBehaviour
{
    public float value;
    public float min;
    public float max;
    public float deltaBydDistance;

    [SerializeField] private UnityEventFloat onValue;

    private Vector3 lastMousePos;

    private void OnValidate()
    {
        if (min > max)
            min = max;
    }

    private void OnMouseDown()
    {
        lastMousePos = Input.mousePosition;
    }

    private void OnMouseDrag()
    {
        var diff = Vector3.Distance(Input.mousePosition, lastMousePos);
        value += diff * deltaBydDistance;
        value = Mathf.Clamp(value, min, max);
        lastMousePos = Input.mousePosition;
        onValue.Invoke(value);
    }
}
