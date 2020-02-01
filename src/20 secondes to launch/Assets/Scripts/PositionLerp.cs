using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionLerp : MonoBehaviour
{
    [SerializeField] private Transform positionA;
    [SerializeField] private Transform positionB;

    public void Set(float t) => transform.position = Vector3.Lerp(positionA.position, positionB.position, t);
}
