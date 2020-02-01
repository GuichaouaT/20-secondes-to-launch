using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurveLoop : MonoBehaviour
{
    [SerializeField] private AnimationCurve curve;
    [SerializeField] private UnityEventFloat onValue;
    [SerializeField] private float duration;

    private float t;

    private void Update()
    {
        t += Time.deltaTime / duration;
        t %= 1;
        onValue.Invoke(curve.Evaluate(t));
    }
}
