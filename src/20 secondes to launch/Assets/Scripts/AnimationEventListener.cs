using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AnimationEventListener : MonoBehaviour
{
#pragma warning disable CS0649
    [SerializeField] private UnityEvent onRaised;
#pragma warning restore CS0649

    public void Raise()
    {
        onRaised.Invoke();
    }

}
