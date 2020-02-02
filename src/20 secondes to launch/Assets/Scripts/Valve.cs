using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Valve : MonoBehaviour
{
#pragma warning disable CS0649
    public float value;
    public float rotationCount;

    [SerializeField] private UnityEventFloat onValueChanged;

#pragma warning restore CS0649

    private bool isDragged = false;
    private float lastAngle;

    private void OnMouseDown()
    {
        isDragged = true;
        lastAngle = GetMouseAngle();
    }

    private void OnMouseUp()
    {
        isDragged = false;
    }

    private void Update()
    {
        if (!isDragged)
            return;

        var angle = GetMouseAngle();
        var diff = angle - lastAngle;
        if (diff == 0)
            return;

        if (diff > 180 || diff < -180)
        {
            if (angle < 0)
                diff = angle + 360 - lastAngle;
            else
                diff = angle - 360 - lastAngle;
        }

        transform.Rotate(0, 0, diff);
        value += (diff / 360f) / rotationCount;
        value = Mathf.Clamp01(value);

        onValueChanged.Invoke(value);
        lastAngle = angle;
    }

    private float GetMouseAngle()
    {
        var pos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        return Mathf.Atan2(pos.y, pos.x) * Mathf.Rad2Deg;
    }

}
