using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Condition : MonoBehaviour
{
    [SerializeField] private FailData failData;

    public FailData FailData => failData;

    public abstract bool IsValid();
}
