using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Switch : MonoBehaviour
{

    public bool value;
    [SerializeField] private UnityEventBool onValue;
    [SerializeField] private UnityEvent isTrue;
    [SerializeField] private UnityEvent isFalse;

    public void Do()
    {
        value ^= true;
        onValue.Invoke(value);
        if (value)
            isTrue.Invoke();
        else
            isFalse.Invoke();
    }

}
