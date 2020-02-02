using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class AnimationEventListenerBase<T, TEvent> : MonoBehaviour where TEvent : UnityEvent<T>
{
#pragma warning disable CS0649
    [SerializeField] private TEvent onRaised;
#pragma warning restore CS0649

    public void Raise(T value)
    {
        onRaised.Invoke(value);
    }

}