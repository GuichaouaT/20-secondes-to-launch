using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoolNot : MonoBehaviour
{
#pragma warning disable CS0649
    [SerializeField] private UnityEventBool onValue;
#pragma warning restore CS0649

    public void Set(bool value) => onValue.Invoke(!value);
}
