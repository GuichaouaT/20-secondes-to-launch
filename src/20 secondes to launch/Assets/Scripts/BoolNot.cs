using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoolNot : MonoBehaviour
{
    [SerializeField] private UnityEventBool onValue;

    public void Set(bool value) => onValue.Invoke(!value);
}
