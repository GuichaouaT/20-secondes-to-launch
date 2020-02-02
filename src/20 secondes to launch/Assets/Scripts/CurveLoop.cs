using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurveLoop : MonoBehaviour
{
#pragma warning disable CS0649
    [SerializeField] private AnimationCurve curve;
    [SerializeField] private UnityEventFloat onValue;
    [SerializeField] private float duration;
#pragma warning restore CS0649

    private float t;

    private void Update()
    {
        t += Time.deltaTime / duration;
        t %= 1;
        onValue.Invoke(curve.Evaluate(t));
    }
}
