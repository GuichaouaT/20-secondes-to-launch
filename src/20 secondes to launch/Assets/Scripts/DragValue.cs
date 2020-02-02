using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragValue : MonoBehaviour
{
#pragma warning disable CS0649    
    public float value;
    public float min;
    public float max;
    public float deltaByDistance;
    public bool resetOnRelease = false;
    public float resetValue = 0;

    [SerializeField] private bool isInteractable;

    [SerializeField] private UnityEventFloat onValue;
#pragma warning restore CS0649

    public bool IsInteractable { get => isInteractable; set => isInteractable = value; }

    private float lastMousePos;

    private void OnValidate()
    {
        if (min > max)
            min = max;
    }

    private void OnMouseDown()
    {
        if (!IsInteractable)
            return;
        lastMousePos = Input.mousePosition.x;
    }

    private void OnMouseUp()
    {
        if (!IsInteractable)
            return;
        if (resetOnRelease)
            SetValue(resetValue);
    }

    private void OnMouseDrag()
    {
        if (!IsInteractable)
            return;
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
