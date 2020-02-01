using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Condition : MonoBehaviour
{
    [SerializeField] private string failAnimation;

    public string FailAnimation => failAnimation;

    public abstract bool IsValid();
}
