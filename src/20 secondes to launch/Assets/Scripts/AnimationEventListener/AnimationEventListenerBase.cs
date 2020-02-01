using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class AnimationEventListenerBase<T, TEvent> : MonoBehaviour where TEvent : UnityEvent<T>
{
    [SerializeField] private TEvent onRaised;

    public void Raise(T value)
    {
        onRaised.Invoke(value);
    }

}