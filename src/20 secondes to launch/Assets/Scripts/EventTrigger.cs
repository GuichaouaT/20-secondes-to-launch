using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTrigger : MonoBehaviour
{
    private readonly List<EventListener> listeners = new List<EventListener>();

    public void Raise()
    {
        for (int i = listeners.Count - 1; i >= 0; i--)
        {
            listeners[i].Trigger();
        }
    }

    public void Subscribe(EventListener listener)
    {
        if (listeners.Contains(listener))
            return;
        listeners.Add(listener);
    }

    public void Unsubscribe(EventListener listener)
    {
        listeners.Remove(listener);
    }
}
