using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StatedAction<T, TEvent> : MonoBehaviour where TEvent : UnityEvent<T>
{
    [SerializeField] public T[] states;
    [SerializeField] public TEvent then;

    private int currentIndex;

    public void Do()
    {
        if (states.Length == 0)
            return;
        currentIndex %= states.Length;
        then.Invoke(states[currentIndex++]);
    }
}
