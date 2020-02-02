using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValueIncrease : MonoBehaviour
{
#pragma warning disable CS0649
    public float value;
    public float min;
    public float max;
    public float speed;
    [SerializeField] private UnityEventFloat onValue;
#pragma warning restore CS0649

    public float Speed { get => speed; set => speed = value; }

    private void OnValidate()
    {
        if (min > max)
            min = max;
    }

    private void Update()
    {
        value += Time.deltaTime * speed;
        value = Mathf.Clamp(value, min, max);
        onValue.Invoke(value);
    }
}
