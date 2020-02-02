using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ClampUpButton : MonoBehaviour
{
#pragma warning disable CS0649
    [SerializeField] private float timeBeforeReset;
    [SerializeField] private int clickNeeded;
    [SerializeField] private UnityEvent onValidate;
#pragma warning restore CS0649

    private int clickCount;
    private float lastClickTime;

    public void BTN_Click()
    {
        lastClickTime = Time.time;
        if (++clickCount == clickNeeded)
        {
            onValidate.Invoke();
        }
    }

    private void Update()
    {
        if (Time.time - lastClickTime > timeBeforeReset)
        {
            clickCount = 0;
        }
    }
}
