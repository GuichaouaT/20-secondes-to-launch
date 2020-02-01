using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValueIncrease : MonoBehaviour
{
    public float value;
    public float speed;
    [SerializeField] private UnityEventFloat onValue;

    public float Speed { get => speed; set => speed = value; }

    private void Update()
    {
        value += Time.deltaTime * speed;
        onValue.Invoke(value);
    }
}
