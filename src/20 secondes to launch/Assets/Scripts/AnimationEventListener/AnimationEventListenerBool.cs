using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEventListenerBool : MonoBehaviour
{
#pragma warning disable CS0649
    [SerializeField] private UnityEventBool onRaised;
#pragma warning restore CS0649

    public void Raise(int value)
    {
        onRaised.Invoke(value != 0);
    }
}
