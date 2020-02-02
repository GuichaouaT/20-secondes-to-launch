using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DoIf : MonoBehaviour
{
#pragma warning disable CS0649
    [SerializeField] private bool active = false;
    [SerializeField] private UnityEvent onAction;
#pragma warning restore CS0649

    public bool Active { set => active = value; }

    public void Do()
    {
        if(active)
        {
            onAction.Invoke();
        }
    }
}
