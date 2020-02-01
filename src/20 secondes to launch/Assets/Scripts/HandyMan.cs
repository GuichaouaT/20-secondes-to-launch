using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HandyMan : MonoBehaviour
{
    [SerializeField] private UnityEvent wingIsOnPlace;
    [SerializeField] private UnityEvent animationEnd;

    public void WingIsPlaced()
    {
        wingIsOnPlace.Invoke();
    }

    public void AnimationEnd()
    {
        animationEnd.Invoke();
    }
}
