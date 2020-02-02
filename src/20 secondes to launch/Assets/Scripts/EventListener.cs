using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventListener : MonoBehaviour
{
#pragma warning disable CS0649
    [SerializeField] private EventTrigger[] triggers;
    [SerializeField] private UnityEvent onTriggered;
#pragma warning restore CS0649

    private void OnEnable()
    {
        foreach (var trigger in triggers)
            trigger.Subscribe(this);
    }

    private void OnDisable()
    {
        foreach (var trigger in triggers)
            trigger.Unsubscribe(this);
    }

    public void Trigger()
    {
        onTriggered.Invoke();
    }
}
