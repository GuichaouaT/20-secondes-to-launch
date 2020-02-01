using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEventListenerBool : MonoBehaviour
{
    [SerializeField] private UnityEventBool onRaised;

    public void Raise(int value)
    {
        onRaised.Invoke(value != 0);
    }
}
