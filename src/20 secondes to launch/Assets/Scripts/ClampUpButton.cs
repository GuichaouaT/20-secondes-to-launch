using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ClampUpButton : MonoBehaviour
{
    [SerializeField] private float timeBeforeReset;
    [SerializeField] private int clickNeeded;
    [SerializeField] private UnityEvent onValidate;

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
