using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateZ : MonoBehaviour
{
    public void Rotate(float angle)
    {
        var euler = transform.localEulerAngles;
        euler.z = angle;
        transform.localEulerAngles = euler;
    }
}
