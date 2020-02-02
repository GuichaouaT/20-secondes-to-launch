using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Condition : MonoBehaviour
{
#pragma warning disable CS0649
    [SerializeField] private string failAnimation;
#pragma warning restore CS0649

    public string FailAnimation => failAnimation;

    public abstract bool IsValid();
}
