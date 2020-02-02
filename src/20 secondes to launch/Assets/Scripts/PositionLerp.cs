using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionLerp : MonoBehaviour
{
#pragma warning disable CS0649
    [SerializeField] private Transform positionA;
    [SerializeField] private Transform positionB;
#pragma warning restore CS0649

    public void Set(float t) => transform.position = Vector3.Lerp(positionA.position, positionB.position, t);
}
